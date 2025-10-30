using FullStackCI.Dtos;
using FullStackCI.Models;
using FullStackCI.Repositories;

namespace FullStackCI.Services
{
    public class AuthorService : IAuthorService
    {
        //private readonly IAuthorRepository _authorRepository;
        /// <summary>
        /// Referencia al repositorio de unidad de trabajo.
        /// </summary>
        private readonly IUnitOfWork _unitOfWorkRepository;

        /// <summary>
        /// Constructor de la clase AuthorService.
        /// </summary>
        /// <param name="iUnitOfWork"></param>
        public AuthorService(IUnitOfWork iUnitOfWork)
        {

            _unitOfWorkRepository = iUnitOfWork;
        }

        /// <summary>
        /// Obtiene todos los autores.
        /// </summary>
        /// <returns>IEnumerable<AuthorDto></returns>
        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _unitOfWorkRepository._authorRepositor.GetAllAsync();
            return authors.Select(ConvertToDto);
        }

        /// <summary>
        /// Obtiene un autor por su ID. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AuthorDto?</returns>
        public async Task<AuthorDto?> GetAuthorByIdAsync(int id)
        {
            var author = await _unitOfWorkRepository._authorRepositor.GetByIdAsync(id);
            return author == null ? null : ConvertToDto(author);
        }

        /// <summary>
        /// Convierte una entidad Author a un AuthorDto.
        /// </summary>
        /// <param name="author"></param>
        /// <returns>AuthorDto</returns>
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
