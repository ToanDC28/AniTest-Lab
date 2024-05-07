using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class FeedbackGv
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime Time { get; set; }

    public virtual Teacher Teacher { get; set; } = null!;
}
