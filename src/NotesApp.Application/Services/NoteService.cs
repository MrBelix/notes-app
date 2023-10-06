using NotesApp.Application.Common;
using NotesApp.Application.Entities;
using NotesApp.Application.Interfaces;

namespace NotesApp.Application.Services;

public class NoteService
{
    private readonly INoteRepository _repository;

    public NoteService(INoteRepository repository)
    {
        _repository = repository;
    }
    
    public Task<PagedList<Note>> SearchAsync(string query, int page = 1)
    {
        return _repository.SearchAsync(query, page);
    }

    public int GetTotalCount()
    {
        return _repository.GetTotalCount();
    }

    public Task Create(Note note)
    {
        if (note is null)
        {
            throw new NullReferenceException(nameof(note));
        }

        if (string.IsNullOrWhiteSpace(note.Title))
        {
            throw new ArgumentNullException(nameof(note.Title));
        }
        
        if (string.IsNullOrWhiteSpace(note.Text))
        {
            throw new ArgumentNullException(nameof(note.Text));
        }

        return _repository.Create(note);
    }

    public Task<Note?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task Update(Note note)
    {
        if (note is null)
        {
            throw new NullReferenceException(nameof(note));
        }

        if (string.IsNullOrWhiteSpace(note.Title))
        {
            throw new ArgumentNullException(nameof(note.Title));
        }
        
        if (string.IsNullOrWhiteSpace(note.Text))
        {
            throw new ArgumentNullException(nameof(note.Text));
        }
        
        return _repository.Update(note);
    }
}