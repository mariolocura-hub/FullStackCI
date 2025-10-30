
using FullStackCI.Data;

namespace FullStackCI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public IBookRepository _bookRepositor { get; set; }
        public IAuthorRepository _authorRepositor { get; set; }
        public ICategoryRepository _categoryRepositor { get; set; }
        public ICategoryCommandRepository _categoryComandRepository { get; set; }
        public IAuthorCommandRepository _authorCommandRepository { get; set; }
        public IBookCommandRepository _bookCommandRepository { get; set; }


        public UnitOfWork(ApplicationDbContext context)
        {

            _context = context;

            _bookRepositor = new BookRepository(context);

            _authorRepositor = new AuthorRepository(context);

            _categoryRepositor = new CategoryRepository(context);

            _categoryComandRepository = new CategoryCommandRepository(context);

            _authorCommandRepository = new AuthorCommandRepository(context);

            _bookCommandRepository = new BookCommandRepository(context);

        }

        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
