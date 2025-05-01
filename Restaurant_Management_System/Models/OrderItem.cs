using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class OrderItem
{
    public int OrderItemsId { get; set; }

    public int? OrderId { get; set; }

    public int? ItemId { get; set; }

    public int Quantity { get; set; }

    public decimal PriceAtTimeOfOrder { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdationDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Order? Order { get; set; }
}
