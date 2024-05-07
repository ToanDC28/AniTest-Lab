using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class FileUpload
{
    public int Id { get; set; }

    public string Uploader { get; set; } = null!;

    public DateTime Time { get; set; }

    public string FileName { get; set; } = null!;
}
