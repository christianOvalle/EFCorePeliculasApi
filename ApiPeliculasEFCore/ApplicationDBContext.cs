using ApiPeliculasEFCore.Entidades;
using ApiPeliculasEFCore.Entidades.Configuraciones;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiPeliculasEFCore
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CineOfertas { get; set; }
        public DbSet<SalaDeCine> SalaDeCines { get; set; }
        public DbSet<PeliculaActor> peliculasActores { get; set; } 
    }
}
