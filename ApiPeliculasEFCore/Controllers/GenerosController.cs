using ApiPeliculasEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public GenerosController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await context.Generos.OrderBy(x=>x.Nombre).ToListAsync();
        }

        [HttpGet("{int:id}")]
        public async Task<ActionResult<Genero>>Get(int id)
        {
            var generoPorId = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if (generoPorId is null)
            {
                return NotFound();
            }

            return generoPorId;
        }

        [HttpGet("primer")]
        public async Task<ActionResult<Genero>> Primer()
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x=>x.Nombre.StartsWith("c"));

            if(genero is null)
            {
                return NotFound();
            }

            return genero;
        }


        [HttpGet("filtrar")]
        public async Task<IEnumerable<Genero>> Filtrar(string nombre)
        {
            return await context.Generos.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
        }

    }
}
