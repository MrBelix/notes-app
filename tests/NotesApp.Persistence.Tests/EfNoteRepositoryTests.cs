using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Entities;
using NotesApp.Persistence.Repositories;

namespace NotesApp.Persistence.Tests;

public class EfNoteRepositoryTests : IDisposable
{
    private readonly DbContextOptions<ApplicationDbContext> _options;
    private readonly ApplicationDbContext _context;
    private readonly EfNoteRepository _repository;

    public EfNoteRepositoryTests()
    {
        // Create an in-memory database for testing
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ApplicationDbContext(_options);
        _repository = new EfNoteRepository(_context);

        // Seed some test data
        _context.Notes.Add(new Note { Title = "Test Note 1", Text = "This is a test note 1" });
        _context.Notes.Add(new Note { Title = "Test Note 2", Text = "This is a test note 2" });
        _context.SaveChanges();
    }

    [Fact]
    public async Task SearchAsync_WithValidQuery_ReturnsPagedList()
    {
        // Arrange
        var query = "Test Note";
        var page = 1;

        // Act
        var result = await _repository.SearchAsync(query, page);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.TotalCount);
        Assert.Equal(2, result.Items.Count(i => i.Title.Contains(query) || i.Text.Contains(query)));
    }

    [Fact]
    public void GetTotalCount_ReturnsTotalCount()
    {
        // Act
        var result = _repository.GetTotalCount();

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task Create_WithValidNote_AddsNoteToDatabase()
    {
        // Arrange
        var note = new Note { Title = "New Note", Text = "This is a new note" };

        // Act
        await _repository.Create(note);

        // Assert
        var addedNote = await _context.Notes.SingleOrDefaultAsync(n => n.Title == "New Note");
        Assert.NotNull(addedNote);
    }

    [Fact]
    public async Task GetByIdAsync_WithValidId_ReturnsNote()
    {
        // Arrange
        var note = await _context.Notes.FirstAsync();
        var id = note.Id;

        // Act
        var result = await _repository.GetByIdAsync(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(note.Id, result.Id);
    }

    [Fact]
    public async Task Update_WithValidNote_UpdatesNoteInDatabase()
    {
        // Arrange
        var note = await _context.Notes.FirstAsync();
        note.Text = "Updated text";

        // Act
        await _repository.Update(note);

        // Assert
        var updatedNote = await _context.Notes.FindAsync(note.Id);
        Assert.NotNull(updatedNote);
        Assert.Equal("Updated text", updatedNote.Text);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}