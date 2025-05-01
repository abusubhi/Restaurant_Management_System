using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderCreationDate { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal? Rate { get; set; }

    public string? Status { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdationDate { get; set; }

    public bool? IsActive { get; set; }

    public int ItemId { get; set; }

    public int ClientId { get; set; }

    public int DriverId { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual User Driver { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
