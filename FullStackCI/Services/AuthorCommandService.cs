using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;

namespace FullStackCI.Services
{
    public class AuthorCommandService : IAuthorCommandService
    {
        //private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWorkRepository;

        public AuthorCommandService(IUnitOfWork iUnitOfWork)
        {

            _unitOfWorkRepository = iUnitOfWork;
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var author = new Author
            {
                Name = createAuthorDto.Name,
                Nationality = createAuthorDto.Nationality,
                BirthYear = createAuthorDto.BirthYear
            };

            var createdAuthor = _unitOfWorkRepository._authorCommandRepository.CreateAsync(author);

            _unitOfWorkRepository.SaveChangesAsync();

            return ConvertToDto(createdAuthor);
        }

        public async Task<AuthorDto?> UpdateAuthorAsync(int id, CreateAuthorDto updateAuthorDto)
        {
            var author = await _unitOfWorkRepository._authorRepositor.GetByIdAsync(id);
            if (author == null) return null;

            author.Name = updateAuthorDto.Name;
            author.Nationality = updateAuthorDto.Nationality;
            author.BirthYear = updateAuthorDto.BirthYear;

            await _unitOfWorkRepository._authorCommandRepository.UpdateAsync(author);
            _unitOfWorkRepository.SaveChangesAsync();

            return ConvertToDto(author);
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            if (!await _unitOfWorkRepository._authorRepositor.ExistsAsync(id))
                return false;

            await _unitOfWorkRepository._authorCommandRepository.DeleteAsync(id);
            _unitOfWorkRepository.SaveChangesAsync();

            return true;
        }

        private AuthorDto ConvertToDto(Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Nationality = author.Nationality,
                BirthYear = author.BirthYear
            };
        }
    }
}
