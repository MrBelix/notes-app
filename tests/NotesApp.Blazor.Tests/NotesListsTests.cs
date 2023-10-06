using Bunit;
using NotesApp.Application.Common;
using NotesApp.Application.Entities;
using NotesApp.Blazor.Shared;

namespace NotesApp.Blazor.Tests;

public class NotesListTests : TestContext
{
    [Fact]
    public void RendersNotesListWithList()
    {
        // Arrange
        var notes = new List<Note>
        {
            new() { Title = "Note 1",  CreatedAt = DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)), Text = "Text 1" },
            new() { Title = "Note 2",  CreatedAt = DateTime.UtcNow.Subtract(TimeSpan.FromHours(2)), Text = "Text 2" }
        };

        var pagedList = new PagedList<Note>(notes, 1, 10, 2);

        // Act
        var cut = RenderComponent<NotesList>(
            ("Data", pagedList) // Directly specify parameter name and value
        );

        // Assert
        cut.Find("h3").MarkupMatches("<h3>Notes</h3>");
        Assert.Equal(2, cut.FindComponents<NoteListItem>().Count); // Assuming you have a CSS class ".note-list-item" for each note item.
        Assert.NotNull(cut.FindComponent<Pagination>());
    }
}