using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class Chat
{
    public int ChatId { get; set; }

    public int UserId { get; set; }

    public int DriverId { get; set; }

    public string Message { get; set; } = null!;

    public string SenderType { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual User Driver { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
