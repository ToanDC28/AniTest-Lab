using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class TeacherNotification
{
    public int Id { get; set; }

    public int NotificationId { get; set; }

    public int TeacherId { get; set; }

    public virtual Notification Notification { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
