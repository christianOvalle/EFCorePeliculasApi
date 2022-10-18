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
    }
}
