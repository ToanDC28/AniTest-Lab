using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Chat
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime TimeSent { get; set; }

    public string ChatContent { get; set; } = null!;

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;
}
