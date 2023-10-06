using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Common;

namespace NotesApp.Persistence.Common;

public class EfPagedList<T> : PagedList<T>
{
    private EfPagedList(List<T> items, int page, int pageSize, int totalCount) 
        : base(items, page, pageSize, totalCount)
    {
    }
    
    public static async Task<EfPagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
    {
        if (page < 1)
        {
            throw new ArgumentException("Page must be greater than or equal to 1", nameof(page));
        }
        
        var totalCount = await query.CountAsync();
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new EfPagedList<T>(items, page, pageSize, totalCount);
    }
}