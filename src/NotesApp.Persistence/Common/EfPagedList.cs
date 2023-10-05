using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Interfaces;

namespace NotesApp.Persistence.Common;

public class EfPagedList<T> : PagedList<T>
{
    private EfPagedList(List<T> items, int page, int pageSize, int totalCount)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }
    
    public static async Task<EfPagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
    {
        var totalCount = await query.CountAsync();
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new EfPagedList<T>(items, page, pageSize, totalCount);
    }
}