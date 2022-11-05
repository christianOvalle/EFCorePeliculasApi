using ApiPeliculasEFCore.Entidades;
using ApiPeliculasEFCore.Entidades.Configuraciones;
using ApiPeliculasEFCore.Entidades.Seeding;
using ApiPeliculasEFCore.Entidades.SinLLave;
using ApiPeliculasEFCore.Servicios;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiPeliculasEFCore
{
    public class ApplicationDBContext : DbContext
    {
        private readonly IservicioUsuario servicioUsuario;

        public ApplicationDBContext(DbContextOptions options, IservicioUsuario servicioUsuario, IEventosDbContext eventosDbContext) : base(options)
        {
            this.servicioUsuario = servicioUsuario;
            if(eventosDbContext is not null)
            {
                //ChangeTracker.Tracked += eventosDbContext.ManejarTracked;
                //ChangeTracker.StateChanged += eventosDbContext.ManejarStateChange;
                SavingChanges += eventosDbContext.ManejarSavingChanges;
                SavedChanges += eventosDbContext.ManejarSavedChanges;
                SaveChangesFailed += eventosDbContext.ManejarSaveChangesFailed;
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcesarSalvado();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcesarSalvado()
        {
            foreach (var item in ChangeTracker.Entries().Where(e=>e.State == EntityState.Added && e.Entity is EntidadAuditable))
            {
                var entidad = item.Entity as EntidadAuditable;
                entidad.UsuarioCreacion = servicioUsuario.ObtenerUsuarioId();
                entidad.UsuarioModificacion = servicioUsuario.ObtenerUsuarioId();
            }

            foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is EntidadAuditable))
            {
                var entidad = item.Entity as EntidadAuditable;
                entidad.UsuarioCreacion = servicioUsuario.ObtenerUsuarioId();
                item.Property(nameof(entidad.UsuarioCreacion)).IsModified = false;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection", opciones =>
                {
                    opciones.UseNetTopologySuite();
                }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
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

            //modelBuilder.Entity<PeliculaConConteos>().HasNoKey().ToView("PeliculasConConteos");

            modelBuilder.Entity<PeliculaConConteos>().ToSqlQuery(@"Select Id, Titulo,
(Select count(*)
from GeneroPelicula
WHERE PeliculasId = Peliculas.Id) as CantidadGeneros,
(Select count(distinct CineId)
FROM PeliculaSalaDeCine
INNER JOIN SalaDeCines
ON SalaDeCines.Id = PeliculaSalaDeCine.SalaDeCineId
WHERE PeliculasId = Peliculas.Id) as CantidadCines,
(
Select count(*)
FROM PeliculasActores
where PeliculaId = Peliculas.Id) as CantidadActores
FROM Peliculas");

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
