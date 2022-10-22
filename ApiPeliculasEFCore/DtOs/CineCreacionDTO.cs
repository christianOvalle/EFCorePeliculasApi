namespace ApiPeliculasEFCore.DtOs
{
    public class CineCreacionDTO
    {
        public string Nombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public CineOfertaCreacionDTO CineOfertaCreacionDTO { get; set; }
        public SalaDeCineCreacionDTO[] SalaDeCineCreacionDTO { get; set; }
    }
}
