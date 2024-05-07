using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectDetail { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
