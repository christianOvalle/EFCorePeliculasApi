using ApiPeliculasEFCore.DtOs;
using ApiPeliculasEFCore.Entidades;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTOs>> Get()
        {
            return await context.Actores.ProjectTo<ActorDTOs>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
