using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Application.Interfaces;
using NotesApp.Persistence.Repositories;

namespace NotesApp.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, DatabaseConfiguration configuration)
    {

        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }
        
        services.AddDbContextFactory<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.ToString()));

        services.AddScoped<INoteRepository, EfNoteRepository>();
        
        return services;
    }
}