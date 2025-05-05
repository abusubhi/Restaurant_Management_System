using System;
using System.Collections.Generic;

namespace Restaurant_Management_System.Models;

public partial class CardPayment
{
    public int CardPaymentId { get; set; }

    public string CardNumber { get; set; } = null!;

    public string CardHolderName { get; set; } = null!;

    public string ExpiryDate { get; set; } 

    public string Cvv { get; set; } = null!;

    public string? CardType { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
