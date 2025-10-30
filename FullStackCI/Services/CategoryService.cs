using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;

namespace FullStackCI.Services
{
    public class CategoryService : ICategoryService
    {
        //private readonly ICategoryRepository _categoryRepository;


        private readonly IUnitOfWork _unitOfWorkRepository;

        public CategoryService(IUnitOfWork iUnitOfWork)
        {
            _unitOfWorkRepository = iUnitOfWork;
        }


        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWorkRepository._categoryRepositor.GetAllAsync();
            return categories.Select(ConvertToDto);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWorkRepository._categoryRepositor.GetByIdAsync(id);
            return category == null ? null : ConvertToDto(category);
        }

        public async Task<CategoryDto2?> GetCategoryByIdAsyncV2(int id)
        {
            var category = await _unitOfWorkRepository._categoryRepositor.GetByIdAsync(id);
            return category == null ? null : ConvertToDto2(category);
        }

        public async Task<bool> GetCategoryExistsAsync(int id)
        {
            var category = await _unitOfWorkRepository._categoryRepositor.ExistsAsync(id);
            return category;
        }

        private CategoryDto ConvertToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        private CategoryDto2 ConvertToDto2(Category category)
        {
            return new CategoryDto2
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Mensaje = "Esto es una prueba de la version 2"
            };
        }
    }
}
