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
           SeedingPersonaMensaje.Seed(modelBuilder);
            //modelBuilder.Ignore<Direccion>();

         
            modelBuilder.Entity<CineSinUbicacion>().HasNoKey().ToSqlQuery("Select Id, Nombre FROM Cines").ToView(null);

            modelBuilder.Entity<PeliculaConConteos>().HasNoKey().ToView("PeliculasConConteos");

            foreach (var tipoEntidad in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var propiedad in tipoEntidad.GetProperties())
                {
                    if(propiedad.ClrType == typeof(string) && propiedad.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
                    {
                        propiedad.SetIsUnicode(false);
                        propiedad.SetMaxLength(500);
                    }
                }
                
            }
            modelBuilder.Entity<Mercancias>().ToTable("Mercancias");
            modelBuilder.Entity<PeliculaAlquilable>().ToTable("PeliculasAlquilables");
            

            var pelicula1 = new PeliculaAlquilable()
            {
                Id = 1,
                Nombre = "Spider-Man",
                PeliculaId = 1,
                Precio = 5.99m
            };

            var merch1 = new Mercancias()
            {
                Id = 2,
                DisponibleEnInventario = true,
                EsRopa = true,
                Nombre = "T-Shirt One Piece",
                Peso = 1,
                Volumen = 1,
                Precio = 11
            };

            modelBuilder.Entity<Mercancias>().HasData(merch1);
            modelBuilder.Entity<PeliculaAlquilable>().HasData(pelicula1);

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CineOfertas { get; set; }
        public DbSet<SalaDeCine> SalaDeCines { get; set; }
        public DbSet<PeliculaActor> peliculasActores { get; set; } 
        public DbSet<CineSinUbicacion> CineSinUbicacion { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<CineDetalle> CineDetalle { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Producto> Productos { get; set; }

    }
}
