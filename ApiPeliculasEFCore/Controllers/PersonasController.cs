using ApiPeliculasEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public PersonasController(ApplicationDBContext context )
        {
            this.context = context;
        }  

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            return await context.Personas.Include(x => x.MensajesRecibidos)
                .Include(c => c.MensajesEnviados)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
