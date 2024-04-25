using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plancraft.Domain.Models.Generic;

namespace Plancraft.Domain.Models;

public class Contract : GenericConfiguration
{
    [Key]
    public Guid ContractId { get; set; }

    public Guid? ProjectId { get; set; }

    public string? Type { get; set; }

    public string? Name { get; set; }

    public decimal? Value { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? GeneralInformation { get; set; }

    public virtual ICollection<ContractItem> ContractItems { get; set; } = new List<ContractItem>();

    public virtual Project? Project { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<PaymentModality> Modalities { get; set; } = new List<PaymentModality>();
}
