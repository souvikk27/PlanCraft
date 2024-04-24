using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plancraft.Domain.Models;

public class Notification
{
    [Key]
    public Guid NotificationId { get; set; }

    public string? Type { get; set; }

    public string? Message { get; set; }

    public DateTime? ScheduledDate { get; set; }

    public DateTime? SentDate { get; set; }

    public string? UserId { get; set; }

    public virtual ApplicationUser? User { get; set; }
}
