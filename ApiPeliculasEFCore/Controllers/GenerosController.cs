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
            return await context.Generos.OrderByDescending(g => EF.Property<DateTime>(g, "FechaCreacion")).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            //var generoPorId = await context.Generos.AsTracking().FirstOrDefaultAsync(x => x.Id == id);

            //var generoPorId = await context.Generos.FromSqlRaw("SeLect * from Generos where Id = {0}", id).IgnoreQueryFilters().FirstOrDefaultAsync();

            var generoPorId = await context.Generos.FromSqlInterpolated($"SeLect * from Generos where Id = {id}").IgnoreQueryFilters().FirstOrDefaultAsync();

            if (generoPorId is null)
            {
                return NotFound();
            }

            var fechaCreacion = context.Entry(generoPorId).Property<DateTime>("FechaCreacion").CurrentValue;

            return Ok(new
            {
                Id = generoPorId.Id,
                Nombre = generoPorId.Nombre,
                fechaCreacion
            });
        }



        [HttpPost]
        public async Task<ActionResult> Post(Genero genero)
        {
            //context.Add(genero);
            //context.Entry(genero).State = EntityState.Added;
            await context.Database.ExecuteSqlInterpolatedAsync($@"Insert into Generos(Nombre) values({genero.Nombre})");
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("varios")]
        public async Task<ActionResult> Post(Genero[] genero)
        {
            context.AddRange(genero);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Genero genero)
        {
            context.Update(genero);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("borradoSuave/{id:int}")]
        public async Task<ActionResult>DeleteSuave(int id)
        {
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(x => x.Id == id);

            if(genero is null)
            {
                return NotFound();
            }

            genero.EstaBorrado = true;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("restaurar/{id:int}")]
        public async Task<ActionResult> Restaurar(int id)
        {
            var genero = await context.Generos.AsTracking().IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.EstaBorrado = false;
            await context.SaveChangesAsync();
            return Ok();
        }

        /*[HttpGet("primer")]
        public async Task<ActionResult<Genero>> Primer()
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Nombre.StartsWith("c"));

            if (genero is null)
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

        [HttpGet("paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>>GetPaginacion(int pagina = 1)
        {
            var cantidadRegistrosPorPagina = 2;
            var genero = await context.Generos.Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToListAsync();
            return genero;
        }*/

    }
}
