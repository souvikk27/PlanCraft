using System;
using System.Collections.Generic;

namespace Plancraft.Domain.Models;

public partial class VwContractDocument
{
    public Guid ContractId { get; set; }

    public string? Type { get; set; }

    public string? Name { get; set; }

    public decimal? Value { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? GeneralInformation { get; set; }

    public Guid? ProjectId { get; set; }

    public Guid? DocumentId { get; set; }

    public string? DocumentName { get; set; }

    public string? DocumentType { get; set; }

    public string? DocumentDescription { get; set; }

    public DateTime? UploadDate { get; set; }

    public int? Version { get; set; }
}
