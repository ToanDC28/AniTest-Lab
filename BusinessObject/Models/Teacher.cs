using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? Permission { get; set; }

    public DateTime LastLogin { get; set; }

    public int GenderId { get; set; }

    public int Notification { get; set; }

    public string? Avatar { get; set; }

    public DateTime Birthday { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<FeedbackGv> FeedbackGvs { get; set; } = new List<FeedbackGv>();

    public virtual Gender Gender { get; set; } = null!;

    public virtual Permission? PermissionNavigation { get; set; }

    public virtual ICollection<TeacherNotification> TeacherNotifications { get; set; } = new List<TeacherNotification>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
