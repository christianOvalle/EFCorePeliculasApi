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

            //builder.HasOne(pa => pa.Actor).WithMany(a => a.PeliculaActores).HasForeignKey(pa => pa.ActorId);

            //builder.HasOne(pa => pa.Pelicula).WithMany(p => p.PeliculaActores).HasForeignKey(pa => pa.PeliculaId);
        }
    }
}
