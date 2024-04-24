using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plancraft.Domain.Models;

public partial class Group
{
    [Key]
    public Guid GroupId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}
