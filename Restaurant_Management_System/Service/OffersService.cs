using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.DTOs.OffersDTO;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Service
{
    public class OffersService:IOffers
    {
        private readonly RMSDbContext _RMSDbContext;
        public OffersService(RMSDbContext RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }

        public async Task<List<OfferDTO>> GetAllOffers(PaginationParameters pagination)
        {
            return await _RMSDbContext
              .Offers
              .AsQueryable()
              .Skip((pagination.PageNumber - 1) * pagination.PageSize)
              .Take(pagination.PageSize)
              .Select(p => new OfferDTO
        {
                  OffersId = p.OffersId,
                  TitleEn=p.TitleEn,
                  TitleAr=p.TitleAr,
                  DescriptionAr=p.DescriptionAr,
                  DescriptionEn=p.DescriptionEn,
              })
              .ToListAsync();
        }

    }
}
