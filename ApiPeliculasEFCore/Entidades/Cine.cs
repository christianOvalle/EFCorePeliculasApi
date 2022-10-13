using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace ApiPeliculasEFCore.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        //[Precision(precision:9,scale:2)]
        public Point ubicacion { get; set; }
        public CineOferta CineOferta { get; set; }
        public HashSet<SalaDeCine> SalaDeCines { get; set; }
    }
}
