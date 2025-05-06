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
          



        }
        
        
        public async Task<List<ItemDTO>> GetTopTenItems()
        {
            var topItems = await _rMSDbContext.Items
                .GroupJoin(
                    _rMSDbContext.OrderItems,
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
                .Select(x => new ItemDTO
                {
                    Id = x.Item.ItemId,
                    NameEn = x.Item.NameEn,
                    NameAr = x.Item.NameAr,
                    OrderCount = x.TotalQuantity
                })
                .ToListAsync();

            return  topItems;
        }
        
        public async Task<ItemDetailsDTO> GetItemById(int itemId)
        {
            if (itemId <= 0)
                throw new ArgumentException("Item ID must be greater than 0.", nameof(itemId));

            return await (from Item in _rMSDbContext.Items

                         join Rate in _rMSDbContext.Rates
                         on Item.ItemId equals Rate.ItemId
                         where Rate.ItemId == itemId
                         select new ItemDetailsDTO
                         {
                             Id = Item.ItemId,
                             NameEn = Item.NameEn,
                             NameAr = Item.NameAr,
                             DescriptionEn = Item.DescriptionEn,
                             DescriptionAr = Item.DescriptionAr,
                             Price = Item.Price,
                             Rate = Rate.ItemRate,
                             NumberOfRevew = _rMSDbContext.Rates
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


