using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto?> GetCategoryByIdAsync(CategoryDto categoryDto);
    Task AddCategoryAsync(CategoryDto categoryDto);
    Task UpdateCategoryAsync(CategoryDto categoryDto);
    Task DeleteCategoryAsync(CategoryDto categoryDto);
    Task<List<CategoryDto>> GetCategoriesWithBookCountAsync();
}