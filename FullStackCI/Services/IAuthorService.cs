using FullStackCI.Dtos;

namespace FullStackCI.Services
{
    public interface IAuthorService
    {
        /// <summary>
        /// Obtiene todos los autores.
        /// </summary>
        /// <returns>IEnumerable<AuthorDto></returns>
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        /// <summary>
        /// Obtiene un autor por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AuthorDto?</returns>
        Task<AuthorDto?> GetAuthorByIdAsync(int id);
    }
}
