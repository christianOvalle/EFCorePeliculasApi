using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPeliculasEFCore.Entidades
{
    public class Actor
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string Biografia { get; set; }
        //[Column(TypeName ="Date")]
        public DateTime? FechaNacimiento { get; set; }
    }
}
