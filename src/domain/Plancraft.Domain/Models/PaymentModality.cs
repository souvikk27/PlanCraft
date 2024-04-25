using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plancraft.Domain.Models.Generic;

namespace Plancraft.Domain.Models;

public class PaymentModality : GenericConfiguration
{
    [Key]
    public Guid ModalityId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PaymentTerms { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
