using HtmlAgilityPack;
using System.Globalization;
using System.Text.RegularExpressions;
using Bible.Crawler.Extensions;
using Bible.Crawler.Abstractions;
using Bible.Crawler.Abstractions.Structures;

namespace Bible.Crawler;

/// <summary>
/// <c> Godpia </c> 에 대한 <see cref="IBibleCrawler" /> 구현체입니다.
/// </summary>
internal sealed partial class GodpiaCrawler : BibleCrawlerBase
{
    /// <summary>
    /// <see cref="GodpiaCrawler" /> 를 초기화합니다.
    /// </summary>
    /// <remarks>
    /// 지원하는 성경 역본 종류는 아래와 같습니다. <br /> <br />
    /// <see cref="VersionType.GAE" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.NIV" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.HAN" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.EASY" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.COGNEW" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.HYUN" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.SAENEW" /> 역본을 지원합니다. <br />
    /// </remarks>
    /// <param name="version"> 성경 역본입니다. </param>
    public GodpiaCrawler(VersionType version) : base(version, new Uri("http://bible.godpia.com/read/reading.asp"))
    {
    }

    /// <inheritdoc cref="BibleCrawlerBase.SupportVersion" />
    public override VersionType SupportVersion => VersionType.GAE | VersionType.NIV | VersionType.HAN | VersionType.EASY | VersionType.COGNEW | VersionType.HYUN | VersionType.SAENEW;

    /// <inheritdoc cref="BibleCrawlerBase.GetChaptersAsync(Book)" />
    public override async IAsyncEnumerable<Chapter> GetChaptersAsync(Book book)
    {
        Uri chapterUri = GetChapterUri(book);
        HtmlDocument document = await LoadAsync(chapterUri).ConfigureAwait(false);
        HtmlNode node = document.GetElementbyId("selectBibleSub3");

        foreach (HtmlNode childNode in node.ChildNodes.Where(node => node.Name.Equals("option", StringComparison.OrdinalIgnoreCase)))
        {
            yield return new Chapter(book, Convert.ToInt32(childNode.InnerText, CultureInfo.InvariantCulture));
        }
    }

    /// <inheritdoc cref="BibleCrawlerBase.GetVersesAsync(Chapter)" />
    public override async IAsyncEnumerable<Verse> GetVersesAsync(Chapter chapter)
    {
        Uri verseUri = GetVerseUri(chapter);
        HtmlDocument document = await LoadAsync(verseUri).ConfigureAwait(false);

        foreach (HtmlNode htmlNode in document.DocumentNode.Descendants("div").Where(htmlNode => htmlNode.GetAttributeValue("class", string.Empty).Contains("wide", StringComparison.OrdinalIgnoreCase)))
        {
            foreach (HtmlNode childNode in htmlNode.ChildNodes.Where(node => node.Name.Equals("p", StringComparison.OrdinalIgnoreCase)))
            {
                string verseNumber = RemoveNumericRegex().Replace(childNode.InnerText, string.Empty);
                string paragraph = childNode.InnerText.Replace(verseNumber, string.Empty, StringComparison.OrdinalIgnoreCase).Trim();

                yield return new Verse(chapter, Convert.ToInt32(verseNumber, CultureInfo.InvariantCulture), paragraph);
            }
        }
    }

    /// <inheritdoc cref="BibleCrawlerBase.GetChapterUri(Book)" />
    protected override Uri GetChapterUri(Book book)
    {
        return BaseUri.AddParameter("ver", CurrentVersion).AddParameter("vol", book.AbbreviationKey);
    }

    /// <inheritdoc cref="BibleCrawlerBase.GetVerseUri(Chapter)" />
    protected override Uri GetVerseUri(Chapter chapter)
    {
        return GetChapterUri(chapter.Book).AddParameter("chap", chapter.Value);
    }

    [GeneratedRegex(@"\D")]
    private static partial Regex RemoveNumericRegex();
}
