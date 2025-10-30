namespace FullStackCI.Dtos
{
    public class RespuestaHaciendaDTO
    {
        public required string Nombre { get; set; }
        public required string TipoIdentificacion { get; set; }
        public required RegimenDTO Regimen { get; set; }
        public required SituacionDTO Situacion { get; set; }
        public required List<ActividadesDTO> Actividades { get; set; }
    }
}
