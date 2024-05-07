using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class StudentNotification
{
    public int Id { get; set; }

    public int NotificationId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Notification Notification { get; set; } = null!;
}
