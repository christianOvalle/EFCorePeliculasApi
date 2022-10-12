using ApiPeliculasEFCore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
    }
}
