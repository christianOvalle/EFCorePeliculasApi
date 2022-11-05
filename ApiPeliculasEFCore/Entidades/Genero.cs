using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPeliculasEFCore.Entidades
{
    //[Table("TablaGeneros", Schema ="Peliculas")]
    //[Index(nameof(Nombre), IsUnique = true)]
    public class Genero : EntidadAuditable
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
