namespace Bible.Crawler.Abstractions.Structures;

/// <summary>
/// 성경의 구절 정보를 가지고 있는 Data Model 입니다.
/// </summary>
public readonly struct Verse
{
    /// <summary>
    /// <see cref="Verse" /> 를 초기화합니다.
    /// </summary>
    /// <param name="chapter"> 성경의 장 정보를 가지고 있는 <see cref="Structures.Chapter" /> 구조체입니다. </param>
    /// <param name="value"> 성경의 절 정보입니다. </param>
    /// <param name="paragraph"> 성경 구절입니다. </param>
    public Verse(Chapter chapter, int value, string paragraph)
    {
        Chapter = chapter;
        Value = value;
        Paragraph = paragraph;
    }

    /// <summary>
    /// 성경 장 정보를 가지고 있는 <see cref="Structures.Chapter" /> 구조체를 가져옵니다.
    /// </summary>
    public Chapter Chapter { get; }

    /// <summary>
    /// 성경 절 정보를 가져옵니다.
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// 성경 구절을 가져옵니다.
    /// </summary>
    public string Paragraph { get; }
}
