using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;

namespace FullStackCI.Services
{
    public class CategoryCommandService : ICategoryCommandService
    {
        //private readonly ICategoryRepository _categoryRepository;


        private readonly IUnitOfWork _unitOfWorkRepository;

        public CategoryCommandService(IUnitOfWork iUnitOfWork)
        {
            _unitOfWorkRepository = iUnitOfWork;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = new Category
            {
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description
            };

            var createdCategory = _unitOfWorkRepository._categoryComandRepository.CreateAsync(category);
            _unitOfWorkRepository.SaveChangesAsync();

            return ConvertToDto(createdCategory);
        }

        public async Task<CategoryDto?> UpdateCategoryAsync(int id, CreateCategoryDto updateCategoryDto)
        {
            var category = await _unitOfWorkRepository._categoryRepositor.GetByIdAsync(id);
            if (category == null) return null;

            category.Name = updateCategoryDto.Name;
            category.Description = updateCategoryDto.Description;

            await _unitOfWorkRepository._categoryComandRepository.UpdateAsync(category);
            _unitOfWorkRepository.SaveChangesAsync();

            return ConvertToDto(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            if (!await _unitOfWorkRepository._categoryRepositor.ExistsAsync(id))
                return false;

            await _unitOfWorkRepository._categoryComandRepository.DeleteAsync(id);// se llama al metodo delete del repositorio
            _unitOfWorkRepository.SaveChangesAsync();

            return true;
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
    }
}
