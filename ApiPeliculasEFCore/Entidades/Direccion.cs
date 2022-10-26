using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPeliculasEFCore.Entidades
{
    [NotMapped]
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string casa { get; set; }
        public string barrio { get; set; }
    }
}
