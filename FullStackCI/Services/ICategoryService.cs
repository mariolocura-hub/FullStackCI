using FullStackCI.Dtos;

namespace FullStackCI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<CategoryDto2?> GetCategoryByIdAsyncV2(int id);
    }
}
