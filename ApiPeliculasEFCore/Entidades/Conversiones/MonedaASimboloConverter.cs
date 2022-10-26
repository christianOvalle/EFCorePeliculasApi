using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiPeliculasEFCore.Entidades.Conversiones
{
    public class MonedaASimboloConverter : ValueConverter<Moneda, string>
    {
        public MonedaASimboloConverter()
            :base(
                 valor => MapeoMonedaString(valor),
                 valor => MapeoStringMoneda(valor)
                 
                 )
        {
                
        }

        private static string MapeoMonedaString(Moneda valor)
        {
            return valor switch
            {
                Moneda.PesoDominicano => "RD$",
                Moneda.DolarEstadoUnidense => "$",
                Moneda.Euro => "€",
                _ => ""
            };
        }

        private static Moneda MapeoStringMoneda(string valor)
        {
            return valor switch
            {
                "RD$" => Moneda.PesoDominicano,
                "$" => Moneda.DolarEstadoUnidense,
                "€" => Moneda.Euro,
                _ => Moneda.Desconocida

            };
        }
    }
}
