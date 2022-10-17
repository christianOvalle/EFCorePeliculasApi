using ApiPeliculasEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Controllers
{
    [ApiController]
    [Route("api/pelicula")]
    public class PeliculaController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public PeliculaController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pelicula>> Get(int id)
        {
            var pelicula = await context.Peliculas.Include(x=>x.Genero).FirstOrDefaultAsync(x => x.Id == id);

            if(pelicula is null)
            {
                return NotFound();
            }

            return pelicula;
        }
    }
}
