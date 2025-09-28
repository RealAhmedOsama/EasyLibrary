using EasyLibrary.Core.Helper;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Services;

public class CategoryService : ICategoryService
{
    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        await using var db = new AppDbContext();
        var categories = await db.Categories
            .Include(c => c.Books.Where(b => b.IsActive))
            .ToListAsync();

        return categories.Select(DtoMapper.MapCategoryToDto).ToList();
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(CategoryDto categoryDto)
    {
        await using var db = new AppDbContext();
        var category = await db.Categories
            .Include(c => c.Books.Where(b => b.IsActive))
            .FirstOrDefaultAsync(c => c.Id == categoryDto.Id);

        return category == null ? null : DtoMapper.MapCategoryToDto(category);
    }

    public async Task AddCategoryAsync(CategoryDto categoryDto)
    {
        await using var db = new AppDbContext();
        var category = DtoMapper.MapDtoToCategory(categoryDto);
        category.CreatedOn = DateTime.Now;
        category.IsActive = true;

        db.Categories.Add(category);
        await db.SaveChangesAsync();
    }

    public async Task UpdateCategoryAsync(CategoryDto categoryDto)
    {
        await using var db = new AppDbContext();
        var category = DtoMapper.MapDtoToCategory(categoryDto);

        db.Categories.Update(category);
        await db.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(CategoryDto categoryDto)
    {
        await using var db = new AppDbContext();
        var category = DtoMapper.MapDtoToCategory(categoryDto);

        db.Categories.Remove(category);
        await db.SaveChangesAsync();
    }

    public async Task<List<CategoryDto>> GetCategoriesWithBookCountAsync()
    {
        return await GetAllCategoriesAsync(); // This already includes book counts
    }
}