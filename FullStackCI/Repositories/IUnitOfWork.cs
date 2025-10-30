using Microsoft.EntityFrameworkCore;

namespace FullStackCI.Repositories
{
    public interface IUnitOfWork : IDisposable
    {

        ICategoryRepository _categoryRepositor { get; }
        IAuthorRepository _authorRepositor { get; }
        IBookRepository _bookRepositor { get; }
        ICategoryCommandRepository _categoryComandRepository { get; }
        IAuthorCommandRepository _authorCommandRepository { get; }
        IBookCommandRepository _bookCommandRepository { get; }


        void SaveChangesAsync();
        

    }
}
