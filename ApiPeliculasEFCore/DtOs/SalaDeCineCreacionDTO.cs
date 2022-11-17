using ApiPeliculasEFCore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.DtOs
{
    public class SalaDeCineCreacionDTO : IId
    {
        public int Id { get; set; }
        public decimal Precio { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
    }
}
