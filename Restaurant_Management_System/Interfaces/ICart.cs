using Restaurant_Management_System.DTOs.CartDTO;
namespace Restaurant_Management_System.IService
{
    public interface ICart
    {
        Task<string> AddItemToCart(CreateCartDTO input);
        Task<List<CartDTO>> GetItemsFromCart(int UserId);
        Task<string> DeleteItemFromCart(int ItemId, int UserId);
        Task<string> DeleteFromCart(int UserId);
    }
}
