using ApiPeliculasEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public ProductosController(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        [HttpGet("Merchs")]
        public async Task<ActionResult<IEnumerable<Mercancias>>> GetMerchs()
        {
            return await context.Set<Mercancias>().ToListAsync();
        }

        [HttpGet("Alquileres")]
        public async Task<ActionResult<IEnumerable<PeliculaAlquilable>>> GetAlquileres()
        {
            return await context.Set<PeliculaAlquilable>().ToListAsync();
        }
    }
}
