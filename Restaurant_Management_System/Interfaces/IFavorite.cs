using Restaurant_Management_System.DTOs.FavoriteDTO;

namespace Restaurant_Management_System.IService
{
    public interface IFavorite
    {
         Task<List<FavoriteDTO>> GetFavoritebyUserId(int UserID);
         Task<string> DeleteItemFromFavorite(int ItemId,int UserId);
         Task<string> AddItemToFavorite(int ItemId, int UserId);
    }
}
