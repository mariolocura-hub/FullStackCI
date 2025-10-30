using FullStackCI.Models;

namespace FullStackCI.Repositories
{
    public interface IBookCommandRepository
    {
        Book CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}
