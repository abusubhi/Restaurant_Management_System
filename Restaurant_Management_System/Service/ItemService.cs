using Microsoft.EntityFrameworkCore;

using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.DTOs.Category;

using Restaurant_Management_System.DTOs.ItemsDTO.Request;
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
                               NameAr = i.NameAr,
                               NameEn = i.NameEn,
                               Image = i.ItemImage,
                               DescriptionAr = i.DescriptionAr,
                               DescriptionEn = i.DescriptionEn,
                               Price = (decimal)i.Price
                           })
                          .ToListAsync();


        }


        public async Task<List<TopRecommendedItemsDTO>> GetTopRecommendedItems()
        {
            var topItems = await _RMSDbContext.Items
                .GroupJoin(
                    _RMSDbContext.OrderItems,
                    item => item.ItemId,
                    orderItem => orderItem.ItemId,
                    (item, orderItems) => new
                    {
                        Item = item,
                        TotalQuantity = orderItems.Sum(oi => (int?)oi.Quantity) ?? 0
                    }
                )
                .OrderByDescending(x => x.TotalQuantity)
                .Take(10)
                .Select(x => new TopRecommendedItemsDTO
                {
                    Id = x.Item.ItemId,
                    NameEn = x.Item.NameEn,
                    NameAr = x.Item.NameAr,
                    DescriptionAr= x.Item.DescriptionAr,
                    DescriptionEn = x.Item.DescriptionEn,
                    Price = x.Item.Price,
                    Image=x.Item.ItemImage
                    
                })
                .ToListAsync();

            return topItems;
        }

        public async Task<ItemDetailsDTO> GetItemById(int itemId)
        {
            if (itemId <= 0)
                throw new ArgumentException("Item ID must be greater than 0.", nameof(itemId));

            return await (from Item in _RMSDbContext.Items

                          join Rate in _RMSDbContext.Rates
                          on Item.ItemId equals Rate.ItemId
                          where Rate.ItemId == itemId
                          select new ItemDetailsDTO
                          {
                              Id = Item.ItemId,
                              NameEn = Item.NameEn,
                              NameAr = Item.NameAr,
                              DescriptionEn = Item.DescriptionEn,
                              DescriptionAr = Item.DescriptionAr,
                              Price = (float)Item.Price,
                              Rate = Rate.ItemRate,
                              NumberOfRevew = _RMSDbContext.Rates
                                      .Count(r => r.ItemId == itemId)

                          }).FirstOrDefaultAsync();

        }


        public async Task<List<ItemDTO>> GetItemsByCategoryId(int categoryId)
        {
            return await _RMSDbContext.Items
        .Where(i => i.CategoryId == categoryId)
        .Select(i => new ItemDTO
        {
            Id = i.ItemId,
            NameAr = i.NameAr,
            NameEn = i.NameEn,
            Image = i.ItemImage,
            DescriptionAr = i.DescriptionAr,
            DescriptionEn = i.DescriptionEn,
            Price = (Decimal)i.Price
        })
       .ToListAsync();
        }


        public async Task<List<TopRatedItemDTO>> GetTopRatedItems()
        {
            var topRatedItems = await _RMSDbContext.Rates
                .GroupBy(r => r.ItemId)
                .Select(g => new
                {
                    ItemId = g.Key,
                    AverageRate = g.Average(r => r.ItemRate)
                })
                .OrderByDescending(r => r.AverageRate)
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

            return topRatedItems;
        }

    }
}


