namespace FullStackCI.Models
{
    public class Author
    {
        /// <summary>
        /// Identificador único del autor.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo del autor.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Nacionalidad del autor.
        /// </summary>
        public string Nationality { get; set; } = string.Empty;
        /// <summary>
        /// Año de nacimiento del autor.
        /// </summary>
        public int BirthYear { get; set; }
        /// <summary>
        /// Colección de libros escritos por el autor.
        /// </summary>
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

}
