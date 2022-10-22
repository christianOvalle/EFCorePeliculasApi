using ApiPeliculasEFCore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.DtOs
{
    public class SalaDeCineCreacionDTO
    {
        
        public decimal Precio { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
    }
}
