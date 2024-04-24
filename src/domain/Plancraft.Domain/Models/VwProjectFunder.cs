using System;
using System.Collections.Generic;

namespace Plancraft.Domain.Models;

public partial class VwProjectFunder
{
    public Guid ProjectId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Budget { get; set; }

    public string? Status { get; set; }

    public Guid? FunderId { get; set; }

    public string? FunderName { get; set; }

    public string? FunderType { get; set; }

    public string? ContactInformation { get; set; }
}
