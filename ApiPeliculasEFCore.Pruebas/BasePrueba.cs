using ApiPeliculasEFCore.Servicios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPeliculasEFCore.Pruebas
{
    public class BasePrueba
    {
        protected ApplicationDBContext ConstruirContext(string nombreDB)
        {
            var opciones = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(nombreDB).Options;

            var servicioUsuario = new ServicioUsuario();

            var dbContext = new ApplicationDBContext(opciones, servicioUsuario, eventosDbContext: null);
            return dbContext;
        }
    }
}