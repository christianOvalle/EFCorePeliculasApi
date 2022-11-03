﻿// <auto-generated />
using System;
using System.Reflection;
using ApiPeliculasEFCore.Entidades;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable disable

namespace ApiPeliculasEFCore.CompiledModels
{
    internal partial class PagoTarjetaEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "ApiPeliculasEFCore.Entidades.PagoTarjeta",
                typeof(PagoTarjeta),
                baseEntityType,
                discriminatorProperty: "TipoPago");

            var ultimos4Digitos = runtimeEntityType.AddProperty(
                "Ultimos4Digitos",
                typeof(string),
                propertyInfo: typeof(PagoTarjeta).GetProperty("Ultimos4Digitos", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PagoTarjeta).GetField("<Ultimos4Digitos>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            ultimos4Digitos.AddAnnotation("Relational:ColumnType", "char(4)");
            ultimos4Digitos.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("DiscriminatorValue", TipoPago.tarjeta);
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Pagos");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
