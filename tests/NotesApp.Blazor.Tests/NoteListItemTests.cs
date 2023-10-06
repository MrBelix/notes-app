using Bunit;
using NotesApp.Application.Entities;
using NotesApp.Blazor.Shared;

namespace NotesApp.Blazor.Tests
{
    public class NoteListItemTests
    {
        [Fact]
        public void RendersNoteCardComponent()
        {
            // Arrange
            using var ctx = new TestContext();

            var note = new Note
            {
                Title = "Test Note",
                Text = "This is a test note.",
                CreatedAt = DateTime.UtcNow.Subtract(TimeSpan.FromHours(2))
            };

            // Act
            var cut = ctx.RenderComponent<NoteListItem>(parameters => parameters.Add(p => p.Item, note));

            // Assert
            cut.MarkupMatches(@"
                <div class=""card"">
                    <div class=""card-header"">
                        <div class=""row align-items-center"">
                            <div class=""col-4"">
                                Test Note
                            </div>
                            <div class=""col-4 text-center"">
                                2 hours ago
                            </div>
                            <div class=""col-4 text-right"">
                                <button class=""btn btn-primary"">View note</button>
                                <a href=""/edit/0"" class=""btn btn-secondary"">Edit note</a>
                            </div>
                        </div>
                    </div>
                </div>
            ");
        }

        [Fact]
        public void TogglesNoteTextVisibility()
        {
            // Arrange
            using var ctx = new TestContext();

            var note = new Note
            {
                Title = "Test Note",
                Text = "This is a test note.",
                CreatedAt = DateTime.UtcNow.Subtract(TimeSpan.FromHours(10))
            };

            var cut = ctx.RenderComponent<NoteListItem>(parameters => parameters.Add(p => p.Item, note));

            // Act
            cut.Find("button").Click(); // Click the "View note" button

            // Assert
            cut.MarkupMatches(@"
                <div class=""card"">
                    <div class=""card-header"">
                        <div class=""row align-items-center"">
                            <div class=""col-4"">
                                Test Note
                            </div>
                            <div class=""col-4 text-center"">
                                10 hours ago
                            </div>
                            <div class=""col-4 text-right"">
                                <button class=""btn btn-primary"">View note</button>
                                <a href=""/edit/0"" class=""btn btn-secondary"">Edit note</a>
                            </div>
                        </div>
                    </div>
                    <div class=""card-body"">
                        This is a test note.
                    </div>
                </div>
            ");

            // Act (toggle off)
            cut.Find("button").Click(); // Click the "View note" button again

            // Assert
            cut.MarkupMatches(@"
                <div class=""card"">
                    <div class=""card-header"">
                        <div class=""row align-items-center"">
                            <div class=""col-4"">
                                Test Note
                            </div>
                            <div class=""col-4 text-center"">
                                10 hours ago
                            </div>
                            <div class=""col-4 text-right"">
                                <button class=""btn btn-primary"">View note</button>
                                <a href=""/edit/0"" class=""btn btn-secondary"">Edit note</a>
                            </div>
                        </div>
                    </div>
                </div>
            ");
        }
    }
}
