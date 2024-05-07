using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string Detail { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
