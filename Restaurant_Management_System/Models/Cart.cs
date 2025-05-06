using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int ClientId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
