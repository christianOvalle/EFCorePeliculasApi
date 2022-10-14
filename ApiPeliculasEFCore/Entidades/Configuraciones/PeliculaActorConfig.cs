using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPeliculasEFCore.Entidades.Configuraciones
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            builder.HasKey(x => new { x.PeliculaId, x.ActorId });
            builder.Property(x => x.Personaje).HasMaxLength(150);
        }
    }
}
