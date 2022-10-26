using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Entidades.SinLLave
{
    //[Keyless]
    public class CineSinUbicacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
