using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class Rate
{
    public int RateId { get; set; }

    public string Message { get; set; } = null!;

    public decimal? ItemRate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdationDate { get; set; }

    public bool? IsActive { get; set; }

    public int UserId { get; set; }

    public int ItemId { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
