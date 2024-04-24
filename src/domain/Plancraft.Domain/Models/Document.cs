using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plancraft.Domain.Models;

public class Document
{
    [Key]
    public Guid DocumentId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public DateTime? UploadDate { get; set; }

    public int? Version { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
