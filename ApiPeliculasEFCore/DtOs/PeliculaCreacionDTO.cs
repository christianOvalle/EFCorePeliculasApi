namespace ApiPeliculasEFCore.DtOs
{
    public class PeliculaCreacionDTO
    {
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<int> Genero { get; set; }
        public List<int> SalaDeCine { get; set; }
        public List<PeliculaActorCreacionDTO> PeliculasActores { get; set; }
    }
}
