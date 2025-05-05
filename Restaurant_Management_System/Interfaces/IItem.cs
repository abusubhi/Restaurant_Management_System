using Restaurant_Management_System.DTOs.ItemsDTO.Request;

namespace Restaurant_Management_System.IService
{
    public interface IItem
    {
        public  Task<List<ItemDTO>> GetTopTenItems();
        public  Task<ItemDetailsDTO> GetItemById(int itemId);
    }
}
