using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.DTOs.CartDTO;
using Restaurant_Management_System.DTOs.FavoriteDTO;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Service
{
    public class CartService : ICart
    {
        private readonly RMSDbContext _RMSDbContext;
        public CartService(RMSDbContext RMSDbContext)
        {
            _RMSDbContext = RMSDbContext;
        }

        public async Task<string> AddItemToCart(CreateCartDTO input)
        {
            var item = await _RMSDbContext.Items.FindAsync(input.ItemId);
            if (item == null)
                return "Item Not Found";

            var client = await _RMSDbContext.Users.FindAsync(input.ClientId);
            if (client == null)
                return "User Not Found";

            var price = item.Price; 
            var cartItem = new Cart
            {
                ClientId = input.ClientId,
                ItemId = input.ItemId,
                Quantity = input.Quantity,
                Price = price,
                TotalPrice = price * input.Quantity,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await _RMSDbContext.Carts.AddAsync(cartItem);
            await _RMSDbContext.SaveChangesAsync();
            return "Added Successfully";
        }

        public async Task<string> DeleteItemFromCart(int ItemId, int UserId)
        {
            var CartItem = await _RMSDbContext.Carts.Where(x => x.ItemId == ItemId && x.ClientId == UserId).FirstOrDefaultAsync();
            if (CartItem == null)
                return "Item not Found";
            _RMSDbContext.Carts.RemoveRange(CartItem);
            await _RMSDbContext.SaveChangesAsync();
            return "Deleted Successfully ";
        }

        public async Task<string> DeleteFromCart(int UserId)
        {
            var existing = await _RMSDbContext.Carts.FindAsync(UserId);
            if (existing is null)
                return "Not Found";
            _RMSDbContext.Carts.Remove(existing);
            await _RMSDbContext.SaveChangesAsync();
            return "Deleted  Successfully";
        }

        public async Task<List<CartDTO>> GetItemsFromCart(int UserId)
        {
            return await (from Carts in _RMSDbContext.Carts
                          join item in _RMSDbContext.Items
                          on Carts.ItemId equals item.ItemId
                          where Carts.ClientId == UserId
                          select new CartDTO
    {
                             ItemId = item.ItemId,
                             NameAr= item.NameAr,
                             NameEn = item.NameEn,
                             DescriptionAr= item.DescriptionAr,
                             DescriptionEn= item.DescriptionEn,
                             Quantity = Carts.Quantity,
                          }).ToListAsync();
        }


    }
}
