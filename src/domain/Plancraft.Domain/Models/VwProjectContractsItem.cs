using System;
using System.Collections.Generic;

namespace Plancraft.Domain.Models;

public partial class VwProjectContractsItem
{
    public Guid ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? ProjectDescription { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Budget { get; set; }

    public string? Status { get; set; }

    public Guid? ContractId { get; set; }

    public string? ContractType { get; set; }

    public string? ContractName { get; set; }

    public decimal? ContractValue { get; set; }

    public DateOnly? ContractStartDate { get; set; }

    public DateOnly? ContractEndDate { get; set; }

    public string? ContractGeneralInformation { get; set; }

    public Guid? ItemId { get; set; }

    public string? ItemName { get; set; }

    public string? ItemDescription { get; set; }

    public decimal? ItemQuantity { get; set; }

    public decimal? ItemUnitPrice { get; set; }

    public string? ItemCurrency { get; set; }

    public string? ItemPaymentSchedule { get; set; }
}
