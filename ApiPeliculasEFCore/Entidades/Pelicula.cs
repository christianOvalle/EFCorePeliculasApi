namespace ApiPeliculasEFCore.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string PosterURL { get; set; }
        public List<SalaDeCine> SalaDeCine { get; set; }
        public List<Genero> Genero { get; set; }
        public List<PeliculaActor> PeliculaActores { get; set; }
    }
}
