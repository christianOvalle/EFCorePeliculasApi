using ApiPeliculasEFCore.DtOs;
using ApiPeliculasEFCore.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await context.Generos.OrderByDescending(g => EF.Property<DateTime>(g, "FechaCreacion")).ToListAsync();
        }

        [HttpGet("procedimiento_almacenado/{id:int}")]
        public async Task<ActionResult<Genero>> GetSP(int id)
        {
            var generos = context.Generos.FromSqlInterpolated($"EXEC Generos_ObtenerPorId {id}").IgnoreQueryFilters().AsAsyncEnumerable();

            await foreach (var genero in generos)
            {
                return genero;
            }

            return NotFound();
        }

        [HttpPost("Procedimiento_almacenado")]
        public async Task<ActionResult>PostSP(Genero genero)
        {
            var existeGeneroConNombre = await context.Generos.AnyAsync(g => g.Nombre == genero.Nombre);

            if (existeGeneroConNombre)
            {
                return BadRequest("Ya existe un genero con ese nombre: " + genero.Nombre);
            }

            var outputId = new SqlParameter();
            outputId.ParameterName = "@id";
            outputId.SqlDbType = System.Data.SqlDbType.Int;
            outputId.Direction = System.Data.ParameterDirection.Output;

            await context.Database.ExecuteSqlRawAsync("EXEC Generos_Insertar @nombre = {0}, @id = {1} OUTPUT", genero.Nombre, outputId);

            var id = (int)outputId.Value;
            return Ok(id);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var generoPorId = await context.Generos.AsTracking().FirstOrDefaultAsync(x => x.Id == id);

            //var generoPorId = await context.Generos.FromSqlRaw("SeLect * from Generos where Id = {0}", id).IgnoreQueryFilters().FirstOrDefaultAsync();

            //var generoPorId = await context.Generos.FromSqlInterpolated($"SeLect * from Generos where Id = {id}").IgnoreQueryFilters().FirstOrDefaultAsync();

            if (generoPorId is null)
            {
                return NotFound();
            }

            var fechaCreacion = context.Entry(generoPorId).Property<DateTime>("FechaCreacion").CurrentValue;
            var periodStart = context.Entry(generoPorId).Property<DateTime>("PeriodStart").CurrentValue;
            var periodEnd = context.Entry(generoPorId).Property<DateTime>("PeriodEnd").CurrentValue;

            return Ok(new
            {
                Id = generoPorId.Id,
                Nombre = generoPorId.Nombre,
                fechaCreacion,
                periodStart,
                periodEnd
            });
        }

        [HttpGet("TemporalAll/{id:int}")]
        public async Task<ActionResult> GetTemporalAll(int id)
        {
            var generos = await context.Generos.TemporalAll().AsTracking()
                .Where(g => g.Id == id)
                .Select(g => new
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    PeriodStart = EF.Property<DateTime>(g, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(g, "PeriodEnd")
                })
                .ToListAsync();

            return Ok(generos);
        }

        [HttpGet("TemporalFromTo/{id:int}")]
        public async Task<ActionResult> GetTemporalFromTo(int id, DateTime desde, DateTime hasta)
        {
            var generos = await context.Generos.TemporalFromTo(desde, hasta).AsTracking()
                .Where(g => g.Id == id)
                .Select(g => new
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    PeriodStart = EF.Property<DateTime>(g, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(g, "PeriodEnd")
                })
                .ToListAsync();

            return Ok(generos);
        }

        [HttpGet("TemporalBetween/{id:int}")]
        public async Task<ActionResult> GetTemporalBetween(int id, DateTime desde, DateTime hasta)
        {
            var generos = await context.Generos.TemporalBetween(desde, hasta).AsTracking()
                .Where(g => g.Id == id)
                .Select(g => new
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    PeriodStart = EF.Property<DateTime>(g, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(g, "PeriodEnd")
                })
                .ToListAsync();

            return Ok(generos);
        }


        [HttpGet("TemporalContainedIn/{id:int}")]
        public async Task<ActionResult> GetTemporalContainedIn(int id, DateTime desde, DateTime hasta)
        {
            var generos = await context.Generos.TemporalContainedIn(desde, hasta).AsTracking()
                .Where(g => g.Id == id)
                .Select(g => new
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    PeriodStart = EF.Property<DateTime>(g, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(g, "PeriodEnd")
                })
                .ToListAsync();

            return Ok(generos);
        }

        [HttpGet("TemporalAsOf/{id:int}")]
        public async Task<ActionResult> GetTemporalAsOf(int id, DateTime fecha)
        {
            var genero = await context.Generos.TemporalAsOf(fecha).AsTracking()
                .Where(g => g.Id == id)
                .Select(g => new
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    PeriodStart = EF.Property<DateTime>(g, "PeriodStart"),
                    PeriodEnd = EF.Property<DateTime>(g, "PeriodEnd")
                }).FirstOrDefaultAsync();

            return Ok(genero);
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
            context.AddRange (genero);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("modificar_varias_veces")]
        public async Task<ActionResult> ModificarVariasVeces()
        {
            var id = 3;
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g => g.Id == id);

            genero.Nombre = "Comedia 2";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            genero.Nombre = "Comedia 3";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            genero.Nombre = "Comedia 4";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            genero.Nombre = "Comedia 5";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            genero.Nombre = "Comedia 6";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            genero.Nombre = "Comedia Actual";
            await context.SaveChangesAsync();
            await Task.Delay(2000);

            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> Put(GeneroActualizacionDTO generoActualizacionDTO)
        {
            var genero = mapper.Map<Genero>(generoActualizacionDTO);
            context.Update(genero);
            context.Entry(genero).Property(g => g.Nombre).OriginalValue = generoActualizacionDTO.Nombre_Original;
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

        [HttpDelete]
        public async Task<ActionResult> Borrar(int id)
        {
            var GeneroAborrar = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            context.Remove(GeneroAborrar);
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


        [HttpPost("restaurar_Borrado/{id:int}")]
        public async Task<ActionResult> Restaurar_Borrado(int id, DateTime date)
        {
            var genero = await context.Generos.TemporalAsOf(date).AsTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (genero is null)
            {
                return NotFound();
            }

            try
            {
                await context.Database.ExecuteSqlInterpolatedAsync($@"
                SET IDENTITY_INSERT Generos ON;
                INSERT INTO Generos (Id, Nombre)
                VALUES ({genero.Id}, {genero.Nombre})
                SET IDENTITY_INSERT Generos OFF;");
            }
            finally
            {
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Generos OFF;");
            }

            return Ok();
        }

        [HttpPost("concurrency_token")]
        public async Task<ActionResult> ConcurrencyToken()
        {
            var generoId = 1;

            // Felipe lee el registro de la BD.
            var genero = await context.Generos.AsTracking().FirstOrDefaultAsync(g => g.Id == generoId);
            genero.Nombre = "Felipe estuvo aquí";

            // Claudia actualiza el registro en la BD.
            await context.Database.ExecuteSqlInterpolatedAsync(@$"UPDATE Generos SET Nombre = 'Claudia estuvo aquí' 
                                                        WHERE Identificador = {generoId}");
            // Felipe intenta actualizar.
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
