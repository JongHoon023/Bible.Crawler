namespace Bible.Crawler.Abstractions.Structures;

/// <summary>
/// 성경의 책 정보를 가지고 있는 구조체입니다.
/// </summary>
public readonly struct Book
{
    /// <summary>
    /// <see cref="Book" /> 을 초기화합니다.
    /// </summary>
    /// <param name="testament"> 구약인지 신약인지에 대한 <see cref="TestamentType" /> 형식의 값입니다. </param>
    /// <param name="abbreviationKey"> 성경 책을 찾을 수 있는 약어 Key 입니다. </param>
    /// <param name="abbreviation"> 성경 책명의 약어입니다. </param>
    /// <param name="name"> 성경 책명입니다. </param>
    public Book(TestamentType testament, string abbreviationKey, string abbreviation, string name)
    {
        Testament = testament;
        AbbreviationKey = abbreviationKey;
        Abbreviation = abbreviation;
        Name = name;
    }

    /// <summary>
    /// 구약인지 신약인지에 대해 <see cref="TestamentType" /> 형식의 값으로 가져옵니다.
    /// </summary>
    public TestamentType Testament { get; }

    /// <summary>
    /// 성경 책을 찾을 수 있는 약어 Key 를 가져옵니다.
    /// </summary>
    public string AbbreviationKey { get; init; }

    /// <summary>
    /// 성경 책명의 약어를 가져옵니다.
    /// </summary>
    public string Abbreviation { get; init; }

    /// <summary>
    /// 성경 책명을 가져옵니다.
    /// </summary>
    public string Name { get; init; }
}
