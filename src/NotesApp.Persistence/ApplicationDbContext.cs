using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Entities;

namespace NotesApp.Persistence;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Note> Notes { get; set; }
}