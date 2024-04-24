using System;
using System.Collections.Generic;

namespace Plancraft.Domain.Models;

public partial class VwFunderProjectsTransaction
{
    public Guid FunderId { get; set; }

    public string? FunderName { get; set; }

    public string? FunderType { get; set; }

    public string? ContactInformation { get; set; }

    public Guid? ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? ProjectDescription { get; set; }

    public DateOnly? ProjectStartDate { get; set; }

    public DateOnly? ProjectEndDate { get; set; }

    public decimal? ProjectBudget { get; set; }

    public string? ProjectStatus { get; set; }

    public Guid? TransactionId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public decimal? TransactionAmount { get; set; }

    public string? PaymentType { get; set; }

    public string? Currency { get; set; }

    public Guid? ItemId { get; set; }

    public string? ItemName { get; set; }

    public string? ItemDescription { get; set; }
}
