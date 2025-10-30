using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;
using FullStackCI.Data;
using Microsoft.EntityFrameworkCore;

namespace FullStackCI.Services
{
    public class BookService : IBookService
    {
        //private readonly IBookRepository _bookRepository;
        private readonly ApplicationDbContext _context;



        private readonly IUnitOfWork _unitOfWorkRepository;

        public BookService(IUnitOfWork iUnitOfWork)
        {
            _unitOfWorkRepository = iUnitOfWork;
        }


        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _unitOfWorkRepository._bookRepositor.GetAllAsync();
            return books.Select(ConvertToDto);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _unitOfWorkRepository._bookRepositor.GetByIdAsync(id);
            return book == null ? null : ConvertToDto(book);
        }

        private BookDto ConvertToDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear,
                Pages = book.Pages,
                Description = book.Description,
                CategoryId = book.CategoryId,
                CategoryName = book.Category?.Name ?? string.Empty,
                AuthorId = book.AuthorId,
                AuthorName = book.Author?.Name ?? string.Empty
            };
        }
    }
}
