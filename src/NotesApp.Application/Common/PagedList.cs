using NotesApp.Application.Entities;

namespace NotesApp.Application.Common;

public class PagedList<T>
{

    public List<T> Items { get; private set;}

    public int Page { get; private set;}
    
    public int PageSize { get; private set; }
    
    public int TotalCount { get; private set;}

    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

    public bool HaveNextPage => Page < TotalPages;

    public bool HavePrevPage => Page > 1;
    
    public PagedList(List<T> items, int page, int pageSize, int totalCount)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }
}