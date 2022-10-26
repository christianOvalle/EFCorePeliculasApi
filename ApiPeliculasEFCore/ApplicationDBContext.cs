using ApiPeliculasEFCore.Entidades;
using ApiPeliculasEFCore.Entidades.Configuraciones;
using ApiPeliculasEFCore.Entidades.Seeding;
using ApiPeliculasEFCore.Entidades.SinLLave;
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
           SeedingConsulta.Seed(modelBuilder);
            //modelBuilder.Ignore<Direccion>();

            modelBuilder.Entity<CineSinUbicacion>().HasNoKey().ToSqlQuery("Select Id, Nombre FROM Cines").ToView(null);

            modelBuilder.Entity<PeliculaConConteos>().HasNoKey().ToView("PeliculasConConteos");

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CineOfertas { get; set; }
        public DbSet<SalaDeCine> SalaDeCines { get; set; }
        public DbSet<PeliculaActor> peliculasActores { get; set; } 
        public DbSet<CineSinUbicacion> CineSinUbicacion { get; set; }
       
    }
}
