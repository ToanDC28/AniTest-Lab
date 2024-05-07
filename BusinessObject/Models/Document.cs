using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Document
{
    public int Id { get; set; }

    public string DocName { get; set; } = null!;

    public string DocPath { get; set; } = null!;

    public int GradeId { get; set; }

    public int SubjectId { get; set; }

    public string Note { get; set; } = null!;

    public int TypeId { get; set; }

    public virtual Grade Grade { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual DocumentType Type { get; set; } = null!;
}
