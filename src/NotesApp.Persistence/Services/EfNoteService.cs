using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Entities;
using NotesApp.Application.Interfaces;
using NotesApp.Application.Services;
using NotesApp.Persistence.Common;

namespace NotesApp.Persistence.Services;

public class EfNoteService: INoteService
{
    private const int NotesPerPage = 10;
    
    private readonly ApplicationDbContext _context;

    public EfNoteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PagedList<Note>> SearchAsync(string search, int page)
    {
        IQueryable<Note> query = _context.Notes;

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(n => n.Title.Contains(search) || n.Text.Contains(search));
        }
        
        query = query.OrderByDescending(n => n.CreatedAt);
        
        return await EfPagedList<Note>.CreateAsync(query, page, NotesPerPage);
    }

    public int GetTotalCount()
    {
        return _context.Notes.Count();
    }

    public async Task Create(Note note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
    }

    public Task<Note?> GetByIdAsync(int id)
    {
        return _context.Notes.SingleOrDefaultAsync(n => n.Id == id);
    }

    public async Task Update(Note note)
    {
        _context.Notes.Update(note);
        await _context.SaveChangesAsync();
    }
}