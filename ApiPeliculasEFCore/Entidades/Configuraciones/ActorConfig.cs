﻿using Microsoft.EntityFrameworkCore;
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
        }
    }
}
