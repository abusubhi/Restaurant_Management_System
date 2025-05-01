using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdationDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
