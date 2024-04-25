using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plancraft.Domain.Models.Generic;

namespace Plancraft.Domain.Models;

public class Setting : GenericConfiguration
{
    [Key]
    public Guid SettingId { get; set; }

    public string Name { get; set; } = null!;

    public string? Value { get; set; }
}
