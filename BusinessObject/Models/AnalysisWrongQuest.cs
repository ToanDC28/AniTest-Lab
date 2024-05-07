using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class AnalysisWrongQuest
{
    public DateTime Time { get; set; }

    public float Correct { get; set; }

    public float Incorrect { get; set; }

    public float Blank { get; set; }
}
