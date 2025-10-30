using FullStackCI.Data;
using FullStackCI.Models;
using FullStackCI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackCITest.Repository
{
    public class BookRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly BookRepository _repository;
        private readonly BookCommandRepository _commandRepository;

        public BookRepositoryTests()
        {
            // Usar base de datos en memoria para tests
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new BookRepository(_context);
            _commandRepository = new BookCommandRepository(_context);
        }

        public void Dispose()
        {

        }

        //[Fact]
        //public async Task GetByIdAsync_ExistingBook_ReturnsBook()
        //{
        //    // Arrange
        //    var book = new Book { Id = 2, Title = "Test Book" };
        //    _commandRepository.CreateAsync(book);
        //    //await _context.SaveChangesAsync(); // no hace falta porque se realiza en el commmand repository
        //    // Act
        //    var result = await _repository.GetByIdAsync(book.Id);
        //    // Assert
        //    Assert.Equal(book.Id, result.Id);
        //    Assert.Equal("Test Book", result.Title);

        //    //result.Should().NotBeNull();
        //    //result.Id.Should().Be(book.Id);
        //    //result.Title.Should().Be("Test Book");
        //}
        [Fact]
        public async Task GetByIdAsync_NonExistingBook_ReturnsNull()
        {
            // Act
            var result = await _repository.GetByIdAsync(2);
            // Assert
            Assert.Null(result);
            //result.Should().BeNull();
        }
        [Fact]
        public async Task AddAsync_ValidBook_AddsToDatabase()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "New Book" };
            // Act
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            // Assert
            var result = await _context.Books.FindAsync(book.Id);

            Assert.NotNull(result);
            Assert.Equal("New Book", result.Title);
            Assert.Equal(1, result.Id);

            //savedBook.Should().NotBeNull();
            //savedBook.Title.Should().Be("New Book");
        }
    }
}

