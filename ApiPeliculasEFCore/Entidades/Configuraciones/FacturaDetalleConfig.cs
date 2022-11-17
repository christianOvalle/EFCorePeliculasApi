using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPeliculasEFCore.Entidades.Configuraciones
{
    public class FacturaDetalleConfig : IEntityTypeConfiguration<FacturaDetalle>
    {
        public void Configure(EntityTypeBuilder<FacturaDetalle> builder)
        {
            builder.Property(x => x.Total).HasComputedColumnSql("precio * Cantidad"); //Stored: True (Para Guargar el valor en la base de datos)
        }
    }
}
