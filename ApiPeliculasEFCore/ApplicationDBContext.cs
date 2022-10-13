using ApiPeliculasEFCore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genero>().HasKey(x => x.Id);
            modelBuilder.Entity<Genero>().Property(x => x.nombre).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Actor>().Property(x => x.nombre).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Actor>().Property(x => x.FechaNacimiento).HasColumnType("date");

            modelBuilder.Entity<Cine>().Property(x => x.nombre).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<SalaDeCine>().Property(x => x.Precio).HasPrecision(precision:  9, scale: 2);

            modelBuilder.Entity<Pelicula>().Property(x => x.Titulo).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Pelicula>().Property(x => x.FechaEstreno).HasColumnName("date");
            modelBuilder.Entity<Pelicula>().Property(x => x.PosterURL).HasMaxLength(500).IsUnicode(false);

            modelBuilder.Entity<CineOferta>().Property(x=>x.PorcentajeDescuento).HasPrecision(precision: 5, scale: 2);
            modelBuilder.Entity<CineOferta>().Property(x => x.FechaInicio).HasColumnType("date");
            modelBuilder.Entity<CineOferta>().Property(x => x.FechaFin).HasColumnType("date");

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CineOfertas { get; set; }
        public DbSet<SalaDeCine> SalaDeCines { get; set; }
    }
}
