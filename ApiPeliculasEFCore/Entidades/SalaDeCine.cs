using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPeliculasEFCore.Entidades
{
    public class SalaDeCine
    {
        public int Id { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
        public decimal Precio { get; set; }
        //[ForeignKey(nameof(CineId))]
        public int CineId { get; set; }
        public Cine Cine { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
        //public Moneda Moneda { get; set; }
    }
}
