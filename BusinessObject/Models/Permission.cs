using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Permission
{
    public int Permission1 { get; set; }

    public string PermissionDetail { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
