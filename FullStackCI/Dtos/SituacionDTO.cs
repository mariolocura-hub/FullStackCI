namespace FullStackCI.Dtos
{
    public class SituacionDTO
    {
        public required string Moroso { get; set; }
        public required string Omiso { get; set; }
        public required string Estado { get; set; }
        public string? AdministracionTributaria { get; set; }
    }
}
