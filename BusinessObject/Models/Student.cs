using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? Permission { get; set; }

    public int ClassId { get; set; }

    public DateTime LastLogin { get; set; }

    public int GenderId { get; set; }

    public int Notification { get; set; }

    public string? Avatar { get; set; }

    public DateTime Birthday { get; set; }

    public int? DoingExam { get; set; }

    public DateTime? StartingTime { get; set; }

    public string? TimeRemaining { get; set; }

    public string? SessionActive { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Gender Gender { get; set; } = null!;

    public virtual Permission? PermissionNavigation { get; set; }

    public virtual Ranking? Ranking { get; set; }

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual ICollection<StudentTestDetail> StudentTestDetails { get; set; } = new List<StudentTestDetail>();
}
