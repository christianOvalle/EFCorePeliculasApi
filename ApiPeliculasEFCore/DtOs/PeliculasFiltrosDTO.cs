namespace ApiPeliculasEFCore.DtOs
{
    public class PeliculasFiltrosDTO
    {
        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public bool EnCartelera { get; set; }
        public bool ProximosExtrenos { get; set; }
    }
}
