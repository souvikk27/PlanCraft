using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plancraft.Domain.Models;

public partial class Setting
{
    [Key]
    public Guid SettingId { get; set; }

    public string Name { get; set; } = null!;

    public string? Value { get; set; }
}
