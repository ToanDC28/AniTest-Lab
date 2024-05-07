using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Level
{
    public int LevelId { get; set; }

    public string? LevelDetail { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
