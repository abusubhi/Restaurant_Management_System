using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Restaurant_Management_System.DTOs.ItemsDTO.Request;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;
using System.Runtime.CompilerServices;

namespace Restaurant_Management_System.Service
{

    public class ItemService : IItem
    {
        private readonly RMSDbContext _rMSDbContext;
        public ItemService(RMSDbContext rMSDbContext)
        {
            _rMSDbContext = rMSDbContext ;
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
            //return await _rMSDbContext.Items
            //    .Where(c => c.ItemId == itemId)
            //    .Select(c => new ItemDTO
            //    {
            //        Id = c.ItemId,
            //        Name = c.NameEn,
            //        Description = c.DescriptionEn,
            //        Price = c.Price,
            //        Image = c.ItemImage,
            //        OrderCount = _rMSDbContext.OrderItems
            //            .Where(o => o.ItemId == itemId)
            //            .Sum(o => (int?)o.Quantity) ?? 0
            //    })
            //    .FirstOrDefaultAsync();
        }


    }
}
