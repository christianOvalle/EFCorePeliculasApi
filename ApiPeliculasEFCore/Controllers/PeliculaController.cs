using ApiPeliculasEFCore.DtOs;
using ApiPeliculasEFCore.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Controllers
{
    [ApiController]
    [Route("api/pelicula")]
    public class PeliculaController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public PeliculaController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTOs>> Get(int id)
        {
            var pelicula = await context.Peliculas
                .Include(x=>x.Genero.OrderByDescending(x=>x.Nombre))
                .Include(x=>x.SalaDeCine)
                .ThenInclude(x=>x.Cine)
                .Include(pa=>pa.PeliculaActores.Where(x=>x.Actor.FechaNacimiento.Value.Year <= 1980))
                .ThenInclude(x=>x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(pelicula is null)
            {
                return NotFound();
            }

            var peliculaDTO = mapper.Map<PeliculaDTOs>(pelicula);

            peliculaDTO.Cines = peliculaDTO.Cines.DistinctBy(x => x.Id).ToList();

            return peliculaDTO;
        }

        [HttpGet("cargaselectiva/{id:int}")]
        public async Task<ActionResult> GetSelectivo(int id)
        {
            var pelicula = await context.Peliculas.Select(x =>
            new
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Generos = x.Genero.OrderByDescending(x => x.Nombre).Select(c => c.Nombre).ToList(),
                cantidadActores = x.PeliculaActores.Count(),
                cantidadCines = x.SalaDeCine.Select(s => s.CineId).Distinct().Count()
            }).FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula is null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        [HttpGet("cargadoexplicito/{id:int}")]
        public async Task<ActionResult<PeliculaDTOs>> GetExplicito(int id)
        {
            var pelicula = await context.Peliculas.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
            //...

            //await context.Entry(pelicula).Collection(x => x.Genero).LoadAsync();

            var cantidadGeneros = await context.Entry(pelicula).Collection(x => x.Genero).Query().CountAsync();

            if (pelicula is null)
            {
                return NotFound();
            }

           var peliculaDTOs = mapper.Map<PeliculaDTOs>(pelicula);

            return peliculaDTOs;
        }
    }
}
