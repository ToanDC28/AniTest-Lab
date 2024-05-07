using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Question
{
    public int GradeId { get; set; }

    public int Unit { get; set; }

    public int LevelId { get; set; }

    public string QuestionContent { get; set; } = null!;

    public string AnswerA { get; set; } = null!;

    public string AnswerB { get; set; } = null!;

    public string AnswerC { get; set; } = null!;

    public string AnswerD { get; set; } = null!;

    public string CorrectAnswer { get; set; } = null!;

    public int QuestionId { get; set; }

    public int SubjectId { get; set; }

    public string SentBy { get; set; } = null!;

    public int StatusId { get; set; }

    public string? HuongDan { get; set; }

    public virtual Grade Grade { get; set; } = null!;

    public virtual Level Level { get; set; } = null!;

    public virtual QuestIncorrectRank? QuestIncorrectRank { get; set; }

    public virtual ICollection<QuestOfTest> QuestOfTests { get; set; } = new List<QuestOfTest>();

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<StudentTestDetail> StudentTestDetails { get; set; } = new List<StudentTestDetail>();

    public virtual Subject Subject { get; set; } = null!;
}
