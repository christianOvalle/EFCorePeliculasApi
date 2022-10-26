using ApiPeliculasEFCore.Entidades.Conversiones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPeliculasEFCore.Entidades.Configuraciones
{
    public class SalaDeCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            builder.Property(x => x.Precio).HasPrecision(precision: 9, scale: 2);
            builder.Property(x => x.TipoSalaDeCine).HasDefaultValue(TipoSalaDeCine.DosDimensiones).HasConversion<string>();
            builder.Property(x => x.Moneda).HasConversion<MonedaASimboloConverter>();
        }
    }
}
