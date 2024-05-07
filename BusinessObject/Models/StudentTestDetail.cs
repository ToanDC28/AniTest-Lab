using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class StudentTestDetail
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int TestCode { get; set; }

    public int QuestionId { get; set; }

    public string? AnswerA { get; set; }

    public string? AnswerB { get; set; }

    public string? AnswerC { get; set; }

    public string? AnswerD { get; set; }

    public string? StudentAnswer { get; set; }

    public DateTime Timest { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Test TestCodeNavigation { get; set; } = null!;
}
