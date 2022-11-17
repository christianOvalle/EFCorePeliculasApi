using System.ComponentModel.DataAnnotations;

namespace ApiPeliculasEFCore.DtOs
{
    public class GeneroActualizacionDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Nombre_Original { get; set; }
    }
}
