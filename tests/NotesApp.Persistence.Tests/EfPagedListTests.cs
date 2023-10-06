using MockQueryable.Moq;
using NotesApp.Persistence.Common;

namespace NotesApp.Persistence.Tests;

public class EfPagedListTests
{
    [Fact]
    public async Task CreateAsync_ShouldCreateEfPagedListCorrectly()
    {
        // Arrange
        var data = Enumerable.Range(1, 100).Select(i => new IntWrapper { Value = i }).ToList(); // Sample data from 1 to 100
        var queryableData = data.AsQueryable();
        var pageSize = 10;
        var page = 3; // Page 3

        // Mock the IQueryable with MockQueryable
        var mockQueryable = queryableData.AsQueryable().BuildMock();

        // Act
        var pagedList = await EfPagedList<IntWrapper>.CreateAsync(mockQueryable, page, pageSize);

        // Assert
        Assert.NotNull(pagedList);
        Assert.Equal(page, pagedList.Page);
        Assert.Equal(pageSize, pagedList.PageSize);
        Assert.Equal(100, pagedList.TotalCount);
        Assert.Equal(10, pagedList.Items.Count);
        Assert.Equal(data.Skip((page - 1) * pageSize).Take(pageSize).ToList(), pagedList.Items);
    }

    [Fact]
    public async Task CreateAsync_ShouldHandleEmptyData()
    {
        // Arrange
        var data = new List<IntWrapper>();
        var queryableData = data.AsQueryable();
        var pageSize = 10;
        var page = 1;

        // Mock the IQueryable with MockQueryable
        var mockQueryable = queryableData.AsQueryable().BuildMock();

        // Act
        var pagedList = await EfPagedList<IntWrapper>.CreateAsync(mockQueryable, page, pageSize);

        // Assert
        Assert.NotNull(pagedList);
        Assert.Equal(page, pagedList.Page);
        Assert.Equal(pageSize, pagedList.PageSize);
        Assert.Equal(0, pagedList.TotalCount);
        Assert.Empty(pagedList.Items);
    }

    [Fact]
    public async Task CreateAsync_ShouldThrowExceptionForNegativePage()
    {
        // Arrange
        var data = Enumerable.Range(1, 100).Select(i => new IntWrapper { Value = i }).ToList();
        var queryableData = data.AsQueryable();
        var pageSize = 10;
        var page = -1; // Negative page

        // Mock the IQueryable with MockQueryable
        var mockQueryable = queryableData.AsQueryable().BuildMock();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => EfPagedList<IntWrapper>.CreateAsync(mockQueryable, page, pageSize));
        Assert.Contains("Page must be greater than or equal to 1", exception.Message);
    }
}

public class IntWrapper
{
    public int Value { get; set; }
}