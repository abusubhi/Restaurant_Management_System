using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.DTOs.Category;
using Restaurant_Management_System.DTOs.Items;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Service
{
    public class ItemService : IItem
    {
        private readonly RMSDbContext _RMSDbContext;
        public ItemService(RMSDbContext RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }


        public async Task<List<ItemDTO>> GetAllItems(PaginationParameters pagination)
        {

            return await _RMSDbContext.Items
           .Skip((pagination.PageNumber - 1) * pagination.PageSize)
           .Take(pagination.PageSize)
                .Select(i => new ItemDTO
                {
                    Id = i.ItemId,
                    NameAR = i.NameAr,
                    NameEN = i.NameEn,
                    ItemImage = i.ItemImage,
                    DescriptionAR = i.DescriptionAr,
                    DescriptionEN = i.DescriptionEn,
                    Price = i.Price
                })
               .ToListAsync();




        }

        public async Task<List<ItemDTO>> GetItemsByCategoryId(int categoryId)
        {
            return await _RMSDbContext.Items
        .Where(i => i.CategoryId == categoryId)
        .Select(i => new ItemDTO
        {
            Id = i.ItemId,
            NameAR = i.NameAr,
            NameEN = i.NameEn,
            ItemImage = i.ItemImage,
            DescriptionAR = i.DescriptionAr,
            DescriptionEN = i.DescriptionEn,
            Price = i.Price
        })
       .ToListAsync();
        }


        public async Task<List<TopRatedItemDTO>> GetTopRatedItems()
        {
            return await (
          from rate in _RMSDbContext.Rates
          group rate by rate.ItemId into rateGroup
          let averageRate = rateGroup.Average(r => r.ItemRate)
          orderby averageRate ascending
          select new { ItemId = rateGroup.Key, AverageRate = averageRate }
      )
      .Take(10)
      .Join(
          _RMSDbContext.Items,
          rating => rating.ItemId,
          item => item.ItemId,
          (rating, item) => new TopRatedItemDTO
          {
              Id = item.ItemId,
              NameAR = item.NameAr,
              NameEN = item.NameEn,
              DescriptionAR = item.DescriptionAr,
              DescriptionEN = item.DescriptionEn,
              ItemImage = item.ItemImage,
              Price = item.Price,
              ItemRate = rating.AverageRate
          }
      )
      .ToListAsync();


        }
    }

}
