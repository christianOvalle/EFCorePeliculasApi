using ApiPeliculasEFCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPeliculasEFCore.Pruebas.Mocks
{
    internal class ConId : IId
    {
        public int Id { get; set; }
    }
}
