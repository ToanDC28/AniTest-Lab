using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string Detail { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
