using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPeliculasEFCore.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable(name: "Generos", opciones =>
            {
                opciones.IsTemporal();
            });

            builder.Property("PeriodStart").HasColumnType("datetime2");
            builder.Property("PeriodEnd").HasColumnType("datetime2");

            //builder.HasKey(x => x.Identificador);
            builder.Property(x => x.Nombre).HasMaxLength(100).IsRequired();

            builder.HasQueryFilter(x => !x.EstaBorrado);

            builder.HasIndex(x=>x.Nombre).IsUnique().HasFilter("EstaBorrado = 'false'");

            builder.Property<DateTime>("FechaCreacion").HasDefaultValueSql("GetDate()").HasColumnType("datetime2");

        }
    }
}
