using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.DTOs.Category;

namespace Restaurant_Management_System.IService
{
    public interface ICategory
    {
        Task<List<CategoryDTO>> GetAllCategory(PaginationParameters pagination);

      


    }
}
 