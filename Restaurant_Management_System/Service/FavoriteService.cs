using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.DTOs.FavoriteDTO;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Service
{
    public class FavoriteService : IFavorite
    {
        private readonly RMSDbContext _RMSDbContext;
        public FavoriteService(RMSDbContext RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }

        public async Task<List<FavoriteDTO>> GetFavoritebyUserId(int UserID)
        {
            return await (from favorite in _RMSDbContext.Favorites
                          join item in _RMSDbContext.Items
                          on favorite.ItemId equals item.ItemId
                          where favorite.UserId == UserID
                          select new FavoriteDTO
                          {
                              Id = item.ItemId,
                              NameAR = item.NameAr,
                              NameEN = item.NameEn,
                              DescriptionAR = item.DescriptionAr,
                              DescriptionEN = item.DescriptionEn,
                              Price = item.Price,
                              CreationDate = item.CreationDate.ToString()
                          }).ToListAsync();

        }

        public async Task<string> DeleteItemFromFavorite(int ItemId,int UserId)
        {
            var favorite = await _RMSDbContext.Favorites.Where(x=> x.ItemId == ItemId && x.UserId==UserId).FirstOrDefaultAsync();
            if (favorite == null)
                return "Item not Found";
            _RMSDbContext.Favorites.RemoveRange(favorite);
            await _RMSDbContext.SaveChangesAsync();
            return "Deleted Successfully ";
        }

        public async Task<string> AddItemToFavorite(int ItemId, int UserId)
        {
            var favorite = new Favorite   
    {
                UserId = UserId,
                ItemId = ItemId,
                CreatedAt = DateTime.UtcNow  
            };

            await _RMSDbContext.Favorites.AddAsync(favorite);  
            await _RMSDbContext.SaveChangesAsync();
            return "Added Successfully";
        }
    }
}
