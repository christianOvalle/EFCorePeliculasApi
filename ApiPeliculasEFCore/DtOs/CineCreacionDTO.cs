namespace ApiPeliculasEFCore.DtOs
{
    public class CineCreacionDTO
    {
        public string Nombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public CineOfertaCreacionDTO CineOferta { get; set; }
        public SalaDeCineCreacionDTO[] SalaDeCines { get; set; }
    }
}
