using System.ComponentModel;

namespace Bible.Crawler.Abstractions.Structures;

/// <summary>
/// 성경 역본 종류입니다.
/// </summary>
public enum VersionType
{
    /// <summary>
    /// <c> 개역개정 </c> 입니다.
    /// </summary>
    [Description("개역개정")]
    GAE,

    /// <summary>
    /// <c> 개역한글 </c> 입니다.
    /// </summary>
    [Description("개역한글")]
    HAN,

    /// <summary>
    /// <c> 표준새번역 </c> 입니다.
    /// </summary>
    [Description("표준새번역")]
    SAE,

    /// <summary>
    /// <c> 새번역 </c> 입니다.
    /// </summary>
    [Description("새번역")]
    SAENEW,

    /// <summary>
    /// <c> 공동번역 </c> 입니다.
    /// </summary>
    [Description("공동번역")]
    COG,

    /// <summary>
    /// <c> 공동번역 개정판 </c> 입니다.
    /// </summary>
    [Description("공동번역 개정판")]
    COGNEW,

    /// <summary>
    /// <c> CEV </c> 입니다.
    /// </summary>
    [Description("CEV")]
    CEV,

    /// <summary>
    /// <c> NIV </c> 입니다.
    /// </summary>
    [Description("NIV")]
    NIV,

    /// <summary>
    /// <c> 쉬운성경 </c> 입니다.
    /// </summary>
    [Description("쉬운성경")]
    EASY,

    /// <summary>
    /// <c> 현대인의 성경 </c> 입니다.
    /// </summary>
    [Description("현대인의 성경")]
    HYUN
}
