using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Rank
{
    public int RankId { get; set; }

    public string RankName { get; set; } = null!;

    public int RankExp { get; set; }

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();
}
