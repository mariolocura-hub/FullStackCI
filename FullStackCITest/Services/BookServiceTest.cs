using FullStackCI.Models;
using FullStackCI.Repositories;
using FullStackCI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackCITest.Services
{
    public class BookServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly BookService _service;

        public BookServiceTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _service = new BookService(_unitOfWork.Object);
        }

        [Fact]
        public void GetAllBooksAsync_ReturnsAllBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1" },
                new Book { Id = 2, Title = "Book 2" }
            };
            _unitOfWork.Setup(u => u._bookRepositor.GetAllAsync())
                       .ReturnsAsync(books);
            // Act
            var result = _service.GetAllBooksAsync().Result;
            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Book 1", result.First().Title);
        }
    }
}
