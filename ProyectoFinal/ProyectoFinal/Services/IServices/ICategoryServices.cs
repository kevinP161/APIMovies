using APIMovies.DAL.Models;
using APIMovies.DAL.Models.Dtos;

namespace APIMovies.Services.IServices
{
    public interface ICategoryServices
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<bool> CategoryExistsByIdAsync(int id);
        Task<bool> CategoryExistsByNameAsync(string name);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto CategoryDto);
        Task<CategoryDto> UpdateCategoryAsync(Category CategoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
