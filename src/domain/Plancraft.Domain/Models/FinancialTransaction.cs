using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plancraft.Domain.Models.Generic;

namespace Plancraft.Domain.Models;

public class FinancialTransaction : GenericConfiguration
{
    [Key]
    public Guid TransactionId { get; set; }

    public DateOnly? Date { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentType { get; set; }

    public string? Currency { get; set; }

    public Guid? ContractItemId { get; set; }

    public Guid? FunderId { get; set; }

    public virtual ContractItem? ContractItem { get; set; }

    public virtual Funder? Funder { get; set; }
}
