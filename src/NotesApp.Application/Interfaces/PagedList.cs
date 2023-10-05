namespace NotesApp.Application.Interfaces;

public abstract class PagedList<T>
{
    public List<T> Items { get; protected set;}

    public int Page { get; protected set;}
    
    public int PageSize { get; protected set; }
    
    public int TotalCount { get; protected set;}

    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

    public bool HaveNextPage => Page < TotalPages;

    public bool HavePrevPage => Page > 1;
}