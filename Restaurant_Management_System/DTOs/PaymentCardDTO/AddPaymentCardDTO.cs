namespace Restaurant_Management_System.DTOs.PaymentCardDTO
{
    public class AddPaymentCardDTO
    {

        public string CardNumber { get; set; } = null!;

        public string CardHolderName { get; set; } = null!;

        public string ExpiryDate { get; set; } 

        public string Cvv { get; set; } = null!;

        public string? CardType { get; set; }

        public int UserId { get; set; }
    }
}
