using System;
using System.Collections.Generic;

namespace AkademiQPortfolio.Entities;

public partial class Skill
{
    public int SkillId { get; set; }

    public string? Skilltitle { get; set; }

    public byte? SkillValue { get; set; }
}
