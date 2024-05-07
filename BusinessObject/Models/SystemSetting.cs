using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class SystemSetting
{
    public int SettingId { get; set; }

    public float Level1A { get; set; }

    public float Level1B { get; set; }

    public float Level2A { get; set; }

    public float Level2B { get; set; }

    public float Level3A { get; set; }

    public float Level3B { get; set; }

    public float Level4A { get; set; }

    public float Level4B { get; set; }

    public int QuestTotalAnalysis { get; set; }
}
