using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPeliculasEFCore.Entidades.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(150).IsRequired();

            builder.Property(x => x.Nombre).HasField("_nombre");

            //builder.Ignore(e => e.Edad);
            //builder.Ignore(x => x.Direccion);

            builder.OwnsOne(x => x.DireccionHogar, dir =>
            {
                dir.Property(c => c.Calle).HasColumnName("Calle");
                dir.Property(c => c.casa).HasColumnName("Casa");
                dir.Property(c => c.barrio).HasColumnName("Barrio");

            });
           
        }
    }
}
