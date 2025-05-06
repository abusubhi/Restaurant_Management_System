using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.DTOs.OffersDTO;

namespace Restaurant_Management_System.IService
{
    public interface IOffers
    {
        Task<List<OfferDTO>> GetAllOffers(PaginationParameters pagination);

        
    }
}
