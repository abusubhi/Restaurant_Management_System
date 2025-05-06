using Restaurant_Management_System.DTOs.PaymentCardDTO;

namespace Restaurant_Management_System.Interfaces
{
    public interface IPaymentCard
    {
         Task<string> AddPaymentCard(AddPaymentCardDTO addPaymentCardDTO);
    }
}
