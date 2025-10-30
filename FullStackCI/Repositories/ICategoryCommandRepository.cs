using FullStackCI.Models;

namespace FullStackCI.Repositories
{
    public interface ICategoryCommandRepository
    {
        Category CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
