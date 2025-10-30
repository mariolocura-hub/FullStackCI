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
    public class AuthorServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly AuthorService _service;

        public AuthorServiceTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _service = new AuthorService(_unitOfWork.Object);
        }

        [Fact]
        public async Task GetAllAuthorsAsync_Success_ReturnsAuthorDtos()
        {
            // Arrange
            var authors = new List<Author>
            {
                new Author { Id = 1, Name = "Pablo Neruda", Nationality = "Chileno", BirthYear = 1950 },
                new Author { Id = 2, Name = "Jorge Luis Borjez", Nationality = "Colombiano", BirthYear = 1960 }
            };

            _unitOfWork.Setup(u => u._authorRepositor.GetAllAsync())
                .ReturnsAsync(authors);

            // Act
            var result = await _service.GetAllAuthorsAsync();

            // Assert
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);
            Assert.Equal("Pablo Neruda", resultList[0].Name);
            Assert.Equal("Jorge Luis Borjez", resultList[1].Name);
        }

        [Fact]
        public async Task GetAuthorByIdAsync_ExistingId_ReturnsAuthorDto()
        {
            // Arrange
            var author = new Author
            {
                Id = 1,
                Name = "Pablo Neruda",
                Nationality = "Chileno",
                BirthYear = 1950
            };

            _unitOfWork.Setup(u => u._authorRepositor.GetByIdAsync(1))
                .ReturnsAsync(author);

            // Act
            var result = await _service.GetAuthorByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Pablo Neruda", result.Name);
            Assert.Equal("Chileno", result.Nationality);
            Assert.Equal(1950, result.BirthYear);
        }

        [Fact]
        public async Task GetAuthorByIdAsync_NonExistingId_ReturnsNull()
        {
            // Arrange
            _unitOfWork.Setup(u => u._authorRepositor.GetByIdAsync(99))
                .ReturnsAsync((Author?)null);

            // Act
            var result = await _service.GetAuthorByIdAsync(99);

            // Assert
            Assert.Null(result);
        }
    }
}
