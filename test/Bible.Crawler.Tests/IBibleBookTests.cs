using Xunit;
using Bible.Crawler.Extensions;
using Bible.Crawler.Abstractions;
using Bible.Crawler.Abstractions.Structures;
using Microsoft.Extensions.DependencyInjection;

namespace Bible.Crawler.Tests;

/// <summary>
/// <see cref="IBibleBook" /> 의 구현체를 Test 하는 Test Class 입니다.
/// </summary>
public sealed class IBibleBookTests
{
    [Fact]
    public void WhenGetBooks_ThenNotEmpty()
    {
        // Given
        IBibleBook bibleBook = CreateBibleBook();

        // When
        IEnumerable<Book> books = bibleBook.GetBooks();

        // Then
        Assert.NotEmpty(books);
    }

    [Fact]
    public async Task WhenGetBooksAsync_ThenNotEmpty_Async()
    {
        // Given
        int count = 0;
        IBibleBook bibleBook = CreateBibleBook();

        // When
        await foreach (Book _ in bibleBook.GetBooksAsync().ConfigureAwait(false))
        {
            count++;
        }

        // Then
        Assert.NotEqual(0, count);
    }

    private IBibleBook CreateBibleBook()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddBibleBook();

        IServiceProvider provider = services.BuildServiceProvider();
        return provider.GetRequiredService<IBibleBook>();
    }
}
