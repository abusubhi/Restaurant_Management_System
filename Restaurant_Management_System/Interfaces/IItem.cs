
using Restaurant_Management_System.DTOs;

using Restaurant_Management_System.DTOs.ItemsDTO.Request;



namespace Restaurant_Management_System.IService
{
    public interface IItem
    {

       Task<List<ItemDTO>> GetAllItems(PaginationParameters pagination);

        Task <List<ItemDTO>> GetItemsByCategoryId(int categoryId);

       Task <List<TopRatedItemDTO>> GetTopRatedItems();



          Task<List<TopRecommendedItemsDTO>> GetTopRecommendedItems();
        Task<ItemDetailsDTO> GetItemById(int itemId);

    }
}
