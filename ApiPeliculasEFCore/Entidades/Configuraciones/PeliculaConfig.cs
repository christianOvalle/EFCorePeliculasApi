using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPeliculasEFCore.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(x => x.Titulo).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PosterURL).HasMaxLength(500).IsUnicode(false);
        }
    }
}
