using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Gender
{
    public int GenderId { get; set; }

    public string GenderDetail { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
