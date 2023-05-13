using System.Text.Json;
using System.Reflection;
using Bible.Crawler.Abstractions;
using Bible.Crawler.Abstractions.Structures;

namespace Bible.Crawler;

/// <summary>
/// <see cref="IBibleBook" /> 의 구현체입니다.
/// </summary>
internal sealed class BibleBook : IBibleBook
{
    private const string JsonFileName = "books.json";
    private readonly Assembly _assembly;

    /// <summary>
    /// <see cref="BibleBook" /> 을 초기화합니다.
    /// </summary>
    public BibleBook()
    {
        _assembly = GetType().Assembly;
    }

    /// <inheritdoc cref="IBibleBook.GetBooks" />
    public IEnumerable<Book> GetBooks()
    {
        using Stream strem = GetJsonFileStream();
        foreach (Book book in JsonSerializer.Deserialize<Book[]>(strem) ?? Array.Empty<Book>())
        {
            yield return book;
        }
    }

    /// <inheritdoc cref="IBibleBook.GetBooksAsync" />
    public async IAsyncEnumerable<Book> GetBooksAsync()
    {
        using Stream strem = GetJsonFileStream();
        await foreach (Book book in JsonSerializer.DeserializeAsyncEnumerable<Book>(strem).ConfigureAwait(false))
        {
            yield return book;
        }
    }

    private Stream GetJsonFileStream()
    {
        if (_assembly.GetManifestResourceNames().FirstOrDefault(name => name.Contains(JsonFileName, StringComparison.OrdinalIgnoreCase)) is string resourceName)
        {
            return _assembly.GetManifestResourceStream(resourceName) ?? Stream.Null;
        }

        return Stream.Null;
    }
}
