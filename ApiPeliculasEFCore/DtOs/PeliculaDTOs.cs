namespace ApiPeliculasEFCore.DtOs
{
    public class PeliculaDTOs
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public ICollection<GeneroDTOs> Genero { get; set; }
        public ICollection<CineDTOs> Cines { get; set; }
        public ICollection<ActorDTOs> Actores { get; set; }
    }
}
