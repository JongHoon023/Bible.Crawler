using Xunit;
using Bible.Crawler.Extensions;
using Bible.Crawler.Abstractions;
using Bible.Crawler.Abstractions.Structures;
using Microsoft.Extensions.DependencyInjection;

namespace Bible.Crawler.Tests;

/// <summary>
/// <c> GODpia </c> 에서 성경을 읽어오는 <see cref="IBibleCrawler" /> 의 구현체를 Test 하는 Test Class 입니다.
/// </summary>
public sealed class GodpiaCrawlerTests
{
    [Fact]
    public async Task GivenGAE_WhenGetVerses_ThenNotEmpty_Async()
    {
        // Given
        IList<Verse> verses = new List<Verse>();
        IBibleBook bibleBook = CreateBibleBook();
        IBibleCrawlerFactory bibleCrawlerFactory = CreateBibleCrawlerFactory();
        IBibleCrawler bibleCrawler = bibleCrawlerFactory.CreateGodpiaCrawler(VersionType.GAE);

        // When
        foreach (Book book in bibleBook.GetBooks())
        {
            await foreach (Chapter chapter in bibleCrawler.GetChaptersAsync(book).ConfigureAwait(false))
            {
                await foreach (Verse verse in bibleCrawler.GetVersesAsync(chapter).ConfigureAwait(false))
                {
                    verses.Add(verse);
                }
            }
        }

        // Then
        Assert.NotEmpty(verses);
    }

    private IBibleBook CreateBibleBook()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddBibleBook();

        IServiceProvider provider = services.BuildServiceProvider();
        return provider.GetRequiredService<IBibleBook>();
    }

    private IBibleCrawlerFactory CreateBibleCrawlerFactory()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddBibleCrawler();

        IServiceProvider provider = services.BuildServiceProvider();
        return provider.GetRequiredService<IBibleCrawlerFactory>();
    }
}
