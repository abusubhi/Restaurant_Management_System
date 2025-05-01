using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class ItemOption
{
    public int OptionId { get; set; }

    public string NameAr { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public bool? IsRequired { get; set; }

    public int ItemId { get; set; }

    public virtual Item Item { get; set; } = null!;
}
