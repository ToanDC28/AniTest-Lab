using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class QuestOfTest
{
    public int TestCode { get; set; }

    public int QuestionId { get; set; }

    public DateTime Timest { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual Test TestCodeNavigation { get; set; } = null!;
}
