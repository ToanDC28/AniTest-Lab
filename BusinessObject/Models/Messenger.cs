using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Messenger
{
    public int Id { get; set; }

    public string UsernameSend { get; set; } = null!;

    public string UsernameGet { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime Time { get; set; }

    public string Type { get; set; } = null!;
}
