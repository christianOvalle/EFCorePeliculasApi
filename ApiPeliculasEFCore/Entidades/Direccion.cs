using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPeliculasEFCore.Entidades
{
    [Owned]
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string casa { get; set; }
        [Required]
        public string barrio { get; set; }
    }
}
