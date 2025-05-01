using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class Otp
{
    public int Otpid { get; set; }

    public int Otpcode { get; set; }

    public DateTime ExpirationTime { get; set; }

    public bool? IsUsed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
