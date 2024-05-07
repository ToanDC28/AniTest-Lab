using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int GradeId { get; set; }

    public string ClassName { get; set; } = null!;

    public int TeacherId { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual Grade Grade { get; set; } = null!;

    public virtual ICollection<StudentNotification> StudentNotifications { get; set; } = new List<StudentNotification>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual Teacher Teacher { get; set; } = null!;
}
