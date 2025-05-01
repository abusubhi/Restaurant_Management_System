using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int? UserId { get; set; }

    public int? ItemId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Item? Item { get; set; }

    public virtual User? User { get; set; }
}
