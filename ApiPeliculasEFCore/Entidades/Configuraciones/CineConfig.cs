using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPeliculasEFCore.Entidades.Configuraciones
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            builder.Property(x => x.nombre).HasMaxLength(150).IsRequired();
        }
    }
}
