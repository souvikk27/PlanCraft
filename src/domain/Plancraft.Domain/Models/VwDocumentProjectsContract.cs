using System;
using System.Collections.Generic;

namespace Plancraft.Domain.Models;

public partial class VwDocumentProjectsContract
{
    public Guid DocumentId { get; set; }

    public string? DocumentName { get; set; }

    public string? DocumentType { get; set; }

    public string? DocumentDescription { get; set; }

    public DateTime? DocumentUploadDate { get; set; }

    public int? DocumentVersion { get; set; }

    public Guid? ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? ProjectDescription { get; set; }

    public DateOnly? ProjectStartDate { get; set; }

    public DateOnly? ProjectEndDate { get; set; }

    public decimal? ProjectBudget { get; set; }

    public string? ProjectStatus { get; set; }

    public Guid? ContractId { get; set; }

    public string? ContractType { get; set; }

    public string? ContractName { get; set; }

    public decimal? ContractValue { get; set; }

    public DateOnly? ContractStartDate { get; set; }

    public DateOnly? ContractEndDate { get; set; }

    public string? ContractGeneralInformation { get; set; }
}
