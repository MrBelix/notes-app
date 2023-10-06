using NotesApp.Application.Common;
using NotesApp.Application.Entities;

namespace NotesApp.Application.Interfaces;

public interface INoteRepository
{
    Task<PagedList<Note>> SearchAsync(string query, int page);
    
    int GetTotalCount();
    
    Task Create(Note note);
    
    Task<Note?> GetByIdAsync(int id);
    
    Task Update(Note model);
}