using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPeliculasEFCore.Entidades.Configuraciones
{
    public class PagoConfig : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.HasDiscriminator(p=>p.TipoPago).HasValue<PagoPaypal>(TipoPago.Paypal).HasValue<PagoTarjeta>(TipoPago.tarjeta);

            builder.Property(x => x.Monto).HasPrecision(18, 2);
        }
    }
}
