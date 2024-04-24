using System;
using System.Collections.Generic;

namespace Plancraft.Domain.Models;

public partial class VwFinancialTransactionDetail
{
    public Guid TransactionId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentType { get; set; }

    public string? Currency { get; set; }

    public Guid? ItemId { get; set; }

    public string? ItemName { get; set; }

    public string? ItemDescription { get; set; }

    public Guid? FunderId { get; set; }

    public string? FunderName { get; set; }

    public string? FunderType { get; set; }

    public string? ContactInformation { get; set; }
}
