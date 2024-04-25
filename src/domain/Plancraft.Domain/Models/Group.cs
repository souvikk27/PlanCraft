using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plancraft.Domain.Models.Generic;

namespace Plancraft.Domain.Models;

public class Group : GenericConfiguration
{
    [Key]
    public Guid GroupId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}
