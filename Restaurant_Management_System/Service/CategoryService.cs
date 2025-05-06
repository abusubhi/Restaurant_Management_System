
﻿using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.DTOs.Category;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;
using static Azure.Core.HttpHeader;

namespace Restaurant_Management_System.Service
{
    public class CategoryService : ICategory
    {
        private readonly RMSDbContext _RMSDbContext;
        public CategoryService(RMSDbContext RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }

        public async Task<List<CategoryDTO>> GetAllCategory(PaginationParameters pagination)
        {
            return await _RMSDbContext
           .Categorys
           .Where(p => p.IsActive == true)
           .Skip((pagination.PageNumber - 1) * pagination.PageSize)
           .Take(pagination.PageSize)
           .Select(p => new CategoryDTO
           {
               Id = p.CategoryId,
               NameAr = p.NameAr,
               NameEn = p.NameEn,
               ImageUrl = p.Image,
               IsActive = p.IsActive ?? false
           })
           .ToListAsync();

        }

}


}