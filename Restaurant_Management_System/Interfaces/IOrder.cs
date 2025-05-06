using Restaurant_Management_System.DTOs.Orders;
using Restaurant_Management_System.DTOs;

namespace Restaurant_Management_System.Interfaces
{
    public interface IOrder
    {
        Task<List<OrderHistoryDTO>> GetOrderHistoryByUserId(int userId, PaginationParameters pagination);
    }
}
