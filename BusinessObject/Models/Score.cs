using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Score
{
    public int StudentId { get; set; }

    public int TestCode { get; set; }

    public string? ScoreNumber { get; set; }

    public string ScoreDetail { get; set; } = null!;

    public DateTime? CompletionTime { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Test TestCodeNavigation { get; set; } = null!;
}
