using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class Offer
{
    public int OffersId { get; set; }

    public string? TitleEn { get; set; }

    public string? DescriptionEn { get; set; }

    public string? TitleAr { get; set; }

    public string? DescriptionAr { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public double? LimitAmount { get; set; }

    public int? LimitPersons { get; set; }

    public string? Code { get; set; }

    public string? Image { get; set; }

    public int? Percentage { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdationDate { get; set; }

    public bool? IsActive { get; set; }

    public int ItemId { get; set; }

    public virtual Item Item { get; set; } = null!;
}
