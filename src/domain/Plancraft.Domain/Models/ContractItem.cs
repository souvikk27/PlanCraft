using System;
using System.Collections.Generic;
using Plancraft.Domain.Models.Generic;

namespace Plancraft.Domain.Models;

public class ContractItem : GenericConfiguration
{
    public Guid ItemId { get; set; }

    public Guid? ContractId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? QuantityOrBudget { get; set; }

    public decimal? UnitPrice { get; set; }

    public string? Currency { get; set; }

    public string? PaymentSchedule { get; set; }

    public virtual Contract? Contract { get; set; }

    public virtual ICollection<FinancialTransaction> FinancialTransactions { get; set; } = new List<FinancialTransaction>();
}
