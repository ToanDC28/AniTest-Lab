using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Ranking
{
    public int StudentId { get; set; }

    public int RankId { get; set; }

    public int Exp { get; set; }

    public int ExpRemaining { get; set; }

    public virtual Rank Rank { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
