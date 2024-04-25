namespace Plancraft.Domain.Models.Generic;

public abstract class GenericConfiguration
{
    public required DateTime CreatedOn { get; set; }
    public  DateTime? UpdatedOn { get; set; }
    public required bool IsRemoved { get; set; }
    public DateTime? RemovedOn { get; set; }
}