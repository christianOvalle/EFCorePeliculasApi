using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPeliculasEFCore.Entidades
{
    //[Table("TablaGeneos", Schema ="Peliculas")]
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        //[StringLength(100)]
        //[MaxLength(100)]
        //[Required]
        //[Column("NombreGenero")]
        
        public string Nombre { get; set; }
        public bool EstaBorrado { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
