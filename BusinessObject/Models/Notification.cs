using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string Username { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string NotificationTitle { get; set; } = null!;

    public string NotificationContent { get; set; } = null!;

    public DateTime TimeSent { get; set; }

    public virtual ICollection<StudentNotification> StudentNotifications { get; set; } = new List<StudentNotification>();

    public virtual ICollection<TeacherNotification> TeacherNotifications { get; set; } = new List<TeacherNotification>();
}
