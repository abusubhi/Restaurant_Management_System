using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string Title { get; set; } = null!;

    public string? NotificationType { get; set; }

    public bool? IsRead { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }
    public string? Content { get; set; }
    public DateTime? CreationDate { get; set; }

    public DateTime? UpdationDate { get; set; }

    public bool? IsActive { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
