using NotesApp.Application.Common;

namespace NotesApp.Application.Tests;

public class PagedListTests
{
    [Fact]
    public void PagedList_ShouldInitializeCorrectly()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3, 4, 5 };
        var page = 1;
        var pageSize = 3;
        var totalCount = 5;

        // Act
        var pagedList = new PagedList<int>(items, page, pageSize, totalCount);

        // Assert
        Assert.NotNull(pagedList);
        Assert.Equal(items, pagedList.Items);
        Assert.Equal(page, pagedList.Page);
        Assert.Equal(pageSize, pagedList.PageSize);
        Assert.Equal(totalCount, pagedList.TotalCount);
        Assert.Equal(2, pagedList.TotalPages);
        Assert.True(pagedList.HaveNextPage);
        Assert.False(pagedList.HavePrevPage);
    }

    [Fact]
    public void PagedList_ShouldCalculateTotalPagesCorrectly()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        var page = 1;
        var pageSize = 3;
        var totalCount = 7;

        // Act
        var pagedList = new PagedList<int>(items, page, pageSize, totalCount);

        // Assert
        Assert.Equal(3, pagedList.TotalPages);
    }

    [Fact]
    public void PagedList_ShouldIndicateHaveNextPage()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3, 4, 5 };
        var page = 1;
        var pageSize = 3;
        var totalCount = 5;

        // Act
        var pagedList = new PagedList<int>(items, page, pageSize, totalCount);

        // Assert
        Assert.True(pagedList.HaveNextPage);
    }

    [Fact]
    public void PagedList_ShouldIndicateHavePrevPage()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3, 4, 5 };
        var page = 2;
        var pageSize = 3;
        var totalCount = 5;

        // Act
        var pagedList = new PagedList<int>(items, page, pageSize, totalCount);

        // Assert
        Assert.True(pagedList.HavePrevPage);
    }
}