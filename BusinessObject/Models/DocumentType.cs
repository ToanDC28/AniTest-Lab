using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class DocumentType
{
    public int TypeId { get; set; }

    public string Detail { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
