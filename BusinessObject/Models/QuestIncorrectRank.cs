using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class QuestIncorrectRank
{
    public int QuestionId { get; set; }

    public int Count { get; set; }

    public int Total { get; set; }

    public float? Ratio { get; set; }

    public int A { get; set; }

    public int B { get; set; }

    public int C { get; set; }

    public int D { get; set; }

    public int Blank { get; set; }

    public int? RatioA { get; set; }

    public int? RatioB { get; set; }

    public int? RatioC { get; set; }

    public int? RatioD { get; set; }

    public virtual Question Question { get; set; } = null!;
}
