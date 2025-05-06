using Restaurant_Management_System.DTOs.Orders;
using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.Interfaces;
using Restaurant_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_Management_System.Service
{

    public class OrderService : IOrder
    {
        private readonly RMSDbContext _RMSDbContext;
        public OrderService(RMSDbContext RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }


        public async Task<List<OrderHistoryDTO>> GetOrderHistoryByUserId(int userId, PaginationParameters pagination)
        {

            var user = await _RMSDbContext.Users
            .Include(u => u.Addresses)
            .FirstOrDefaultAsync(u => u.UserId == userId);


            var address = user.Addresses.FirstOrDefault();
            string fullAddress = address != null ? $"{address.Region}, {address.Province}" : "No Address";

            return await _RMSDbContext.Orders
                .Where(o => o.ClientId == userId && o.IsActive == true)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(o => new OrderHistoryDTO
                {
                    OrderId = o.OrderId,
                    Address = fullAddress,
                    OrderDate = o.OrderCreationDate,
                    TotalPrice = o.TotalPrice
                })
                .ToListAsync();

            
        }


    }


}
