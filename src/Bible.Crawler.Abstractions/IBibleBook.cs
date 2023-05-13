using Bible.Crawler.Abstractions.Structures;

namespace Bible.Crawler.Abstractions;

/// <summary>
/// 성경의 책 정보를 가져오는 Service 입니다.
/// </summary>
public interface IBibleBook
{
    /// <summary>
    /// 성경의 책 정보를 순차적으로 가져옵니다.
    /// </summary>
    /// <returns> 성경의 책 정보가 있는 <see cref="Book" /> 구조체를 순차적으로 반환합니다. </returns>
    IEnumerable<Book> GetBooks();

    /// <summary>
    /// 성경의 책 정보를 비동기로 순차적으로 가져옵니다.
    /// </summary>
    /// <returns> 성경의 책 정보가 있는 <see cref="Book" /> 구조체를 순차적으로 반환합니다. </returns>
    IAsyncEnumerable<Book> GetBooksAsync();
}
