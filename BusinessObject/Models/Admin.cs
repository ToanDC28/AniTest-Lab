using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? Permission { get; set; }

    public DateTime LastLogin { get; set; }

    public int GenderId { get; set; }

    public string? Avatar { get; set; }

    public DateTime Birthday { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual Permission? PermissionNavigation { get; set; }
}
