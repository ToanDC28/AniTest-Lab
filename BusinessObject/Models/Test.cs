using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Test
{
    public int TestCode { get; set; }

    public string TestName { get; set; } = null!;

    public int TestType { get; set; }

    public string Password { get; set; } = null!;

    public int? SubjectId { get; set; }

    public int GradeId { get; set; }

    public int TotalQuestions { get; set; }

    public int TimeToDo { get; set; }

    public string Note { get; set; } = null!;

    public int? StatusId { get; set; }

    public DateTime Timest { get; set; }

    public int CreatedBy { get; set; }

    public virtual Teacher CreatedByNavigation { get; set; } = null!;

    public virtual Grade Grade { get; set; } = null!;

    public virtual ICollection<QuestOfTest> QuestOfTests { get; set; } = new List<QuestOfTest>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual Status? Status { get; set; }

    public virtual ICollection<StudentTestDetail> StudentTestDetails { get; set; } = new List<StudentTestDetail>();

    public virtual Subject? Subject { get; set; }
}
