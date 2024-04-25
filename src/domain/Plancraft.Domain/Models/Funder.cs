using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plancraft.Domain.Models.Generic;

namespace Plancraft.Domain.Models;

public class Funder : GenericConfiguration
{
    [Key]
    public Guid FunderId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? ContactInformation { get; set; }

    public virtual ICollection<FinancialTransaction> FinancialTransactions { get; set; } = new List<FinancialTransaction>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
