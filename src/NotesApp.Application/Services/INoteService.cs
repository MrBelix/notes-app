using NotesApp.Application.Entities;
using NotesApp.Application.Interfaces;

namespace NotesApp.Application.Services;

public interface INoteService
{
    Task<PagedList<Note>> SearchAsync(string query, int page);
    
    int GetTotalCount();
    
    Task Create(Note note);
    
    Task<Note?> GetByIdAsync(int id);
    
    Task Update(Note model);
}