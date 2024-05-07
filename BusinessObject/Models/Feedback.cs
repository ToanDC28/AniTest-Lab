using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime Time { get; set; }

    public virtual Student Student { get; set; } = null!;
}
