using Restaurant_Management_System.DTOs.PaymentCardDTO;

namespace Restaurant_Management_System.Interfaces
{
    public interface IAddPaymentCard
    {
        public Task<string> AddPaymentCard(AddPaymentCardDTO addPaymentCardDTO);
    }
}
