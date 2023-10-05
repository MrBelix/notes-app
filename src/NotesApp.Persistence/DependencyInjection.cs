using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Application.Services;
using NotesApp.Persistence.Services;

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

        services.AddScoped<INoteService, EfNoteService>();
        
        return services;
    }
}