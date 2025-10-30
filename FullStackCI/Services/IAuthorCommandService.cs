using FullStackCI.Dtos;

namespace FullStackCI.Services
{
    public interface IAuthorCommandService
    {
        /// <summary>
        /// Medo de crear un autor.
        /// </summary>
        /// <param name="createAuthorDto"></param>
        /// <returns>AuthorDto</returns>
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto);
        /// <summary>
        /// Metodo de actualizar un autor   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateAuthorDto"></param>
        /// <returns>AuthorDto?</returns>
        Task<AuthorDto?> UpdateAuthorAsync(int id, CreateAuthorDto updateAuthorDto);
        /// <summary>
        /// Metodo de eliminar un autor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        Task<bool> DeleteAuthorAsync(int id);
    }
}
