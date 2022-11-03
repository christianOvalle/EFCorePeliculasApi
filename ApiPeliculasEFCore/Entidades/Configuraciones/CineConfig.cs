using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPeliculasEFCore.Entidades.Configuraciones
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(150).IsRequired();

            builder.HasOne(x => x.CineOferta).WithOne().HasForeignKey<CineOferta>(x => x.CineId);

            builder.HasMany(c => c.SalaDeCines).WithOne(x => x.Cine).HasForeignKey(s => s.CineId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CineDetalle).WithOne(cd => cd.Cine).HasForeignKey<CineDetalle>(cd => cd.Id);

            builder.OwnsOne(c => c.Direccion, dir =>
            {
                dir.Property(c => c.Calle).HasColumnName("Calle");
                dir.Property(c => c.casa).HasColumnName("casa");
                dir.Property(c => c.barrio).HasColumnName("barrio");

            });


        }
    }
}
