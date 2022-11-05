﻿using ApiPeliculasEFCore.DtOs;
using ApiPeliculasEFCore.Entidades;
using ApiPeliculasEFCore.Entidades.SinLLave;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace ApiPeliculasEFCore.Controllers
{
    [ApiController]
    [Route("api/cine")]
    public class CineController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public CineController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CineDTOs>> Get()
        {
            return await context.Cines.ProjectTo<CineDTOs>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //var cine = await context.Cines.FirstOrDefaultAsync(x => x.Id == id);

            var cine = await context.Cines.FromSqlInterpolated($"select * from Cines where Id = {id}")
                       .Include(x => x.SalaDeCines)
                       .Include(x => x.CineOferta)
                       .Include(x => x.CineDetalle)
                       .FirstOrDefaultAsync();
            cine.Ubicacion = null;

            return Ok(cine);
        }




        [HttpGet("SinUbicacion")]
        public async Task<IEnumerable<CineSinUbicacion>> GetCineSinUbicacion()
        {
            return await context.CineSinUbicacion.ToListAsync();
        }

        [HttpGet("cercanos")]
        public async Task<ActionResult> Get(double latitud, double longitud)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var miUbicacion = geometryFactory.CreatePoint(new Coordinate(longitud, latitud));

            var distanciaMaximaMetros = 2000;

            var cines = await context.Cines
                .OrderBy(c => c.Ubicacion.Distance(miUbicacion))
                .Where(c => c.Ubicacion.IsWithinDistance(miUbicacion, distanciaMaximaMetros))
                .Select(x => new
                {
                    Nombre = x.Nombre,
                    Distancia = Math.Round(x.Ubicacion.Distance(miUbicacion))
                }).ToListAsync();

            return Ok(cines);
        }

        [HttpPost("conDTO")]
        public async Task<ActionResult> Post(CineCreacionDTO cineCreacionDTO)
        {
            var cine = mapper.Map<Cine>(cineCreacionDTO);
            context.Add(cine);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Borrar(int id)
        {
            var cine = await context.Cines.Include(x=>x.SalaDeCines).Include(x=>x.CineOferta).FirstOrDefaultAsync(x => x.Id == id);

            if (cine == null)
            {
                return NotFound();
            }

            context.RemoveRange(cine);
            await context.SaveChangesAsync();

            context.Remove(cine);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
