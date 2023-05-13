namespace Bible.Crawler.Abstractions.Structures;

/// <summary>
/// 성경의 장 정보를 가지고 있는 Data Model 입니다.
/// </summary>
public readonly struct Chapter
{
    /// <summary>
    /// <see cref="Chapter" /> 를 초기화합니다.
    /// </summary>
    /// <param name="book"> 성경의 책 정보를 가지고 있는 <see cref="Structures.Book" /> 구조체입니다. </param>
    /// <param name="value"> 현재 성경의 장 정보입니다. </param>
    public Chapter(Book book, int value)
    {
        Book = book;
        Value = value;
    }

    /// <summary>
    /// 성경의 책 정보를 가지고 있는 <see cref="Structures.Book" /> 구조체를 가져옵니다.
    /// </summary>
    public Book Book { get; }

    /// <summary>
    /// 현재 성경의 장 정보를 가져옵니다.
    /// </summary>
    public int Value { get; }
}
