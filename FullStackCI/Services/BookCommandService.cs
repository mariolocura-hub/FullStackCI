using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;
using FullStackCI.Data;
using Microsoft.EntityFrameworkCore;

namespace FullStackCI.Services
{
    public class BookCommandService : IBookCommandService
    {
        //private readonly IBookRepository _bookRepository;
        private readonly ApplicationDbContext _context;



        private readonly IUnitOfWork _unitOfWorkRepository;

        public BookCommandService(IUnitOfWork iUnitOfWork)
        {
            _unitOfWorkRepository = iUnitOfWork;
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            // Verificar que el autor existe
            var authorExists = await _unitOfWorkRepository._authorRepositor.ExistsAsync(createBookDto.AuthorId);
            if (!authorExists)
            {
                throw new ArgumentException("El autor especificado no existe");
            }

            // Verificar que la categoría existe

            var categoryExists = await _unitOfWorkRepository._categoryRepositor.ExistsAsync(createBookDto.CategoryId);
            if (!categoryExists)
            {
                throw new ArgumentException("La categoría especificada no existe");
            }


            var book = new Book
            {
                Title = createBookDto.Title,
                ISBN = createBookDto.ISBN,
                PublicationYear = createBookDto.PublicationYear,
                Pages = createBookDto.Pages,
                Description = createBookDto.Description,
                CategoryId = createBookDto.CategoryId,
                AuthorId = createBookDto.AuthorId
            };

            var createdBook = _unitOfWorkRepository._bookCommandRepository.CreateAsync(book);
            _unitOfWorkRepository.SaveChangesAsync();

            return ConvertToDto(createdBook);
        }
        /*public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            // Verificar que el autor existe
            var authorExists = await _context.Authors.AnyAsync(a => a.Id == createBookDto.AuthorId);
            if (!authorExists)
            {
                throw new ArgumentException("El autor especificado no existe");
            }

            // Verificar que la categoría existe
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == createBookDto.CategoryId);
            if (!categoryExists)
            {
                throw new ArgumentException("La categoría especificada no existe");
            }

            var book = new Book
            {
                Title = createBookDto.Title,
                ISBN = createBookDto.ISBN,
                PublicationYear = createBookDto.PublicationYear,
                Pages = createBookDto.Pages,
                Description = createBookDto.Description,
                CategoryId = createBookDto.CategoryId,
                AuthorId = createBookDto.AuthorId
            };

            var createdBook = _unitOfWorkRepository._bookCommandRepository.CreateAsync(book);
            _unitOfWorkRepository.SaveChangesAsync();

            return ConvertToDto(createdBook);
        }*/

        public async Task<BookDto?> UpdateBookAsync(int id, UpdateBookDto updateBookDto)
        {
            var book = await _unitOfWorkRepository._bookRepositor.GetByIdAsync(id);
            if (book == null) return null;

            // Verificar que el autor existe
            var authorExists = await _unitOfWorkRepository._authorRepositor.ExistsAsync(updateBookDto.AuthorId);
            if (!authorExists)
            {
                throw new ArgumentException("El autor especificado no existe");
            }


            // Verificar que la categoría existe
            var categoryExists = await _unitOfWorkRepository._categoryRepositor.ExistsAsync(updateBookDto.CategoryId);
            if (!categoryExists)
            {
                throw new ArgumentException("La categoría especificada no existe");
            }


            book.Title = updateBookDto.Title;
            book.ISBN = updateBookDto.ISBN;
            book.PublicationYear = updateBookDto.PublicationYear;
            book.Pages = updateBookDto.Pages;
            book.Description = updateBookDto.Description;
            book.CategoryId = updateBookDto.CategoryId;
            book.AuthorId = updateBookDto.AuthorId;

            await _unitOfWorkRepository._bookCommandRepository.UpdateAsync(book);
            _unitOfWorkRepository.SaveChangesAsync();

            return ConvertToDto(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            if (!await _unitOfWorkRepository._bookRepositor.ExistsAsync(id))
                return false;

            await _unitOfWorkRepository._bookCommandRepository.DeleteAsync(id);
            _unitOfWorkRepository.SaveChangesAsync();

            return true;
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
