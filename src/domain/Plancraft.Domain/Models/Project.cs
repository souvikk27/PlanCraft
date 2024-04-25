using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plancraft.Domain.Models.Generic;

namespace Plancraft.Domain.Models;

public class Project : GenericConfiguration 
{
    [Key]
    public Guid ProjectId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Budget { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Funder> Funders { get; set; } = new List<Funder>();

    public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}
