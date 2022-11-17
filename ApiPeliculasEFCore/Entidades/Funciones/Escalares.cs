using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Entidades.Funciones
{
    public static class Escalares
    {
        public static void RegistrarFunciones(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(() => FacturaDetallePromedio(0));
        }

        public static decimal FacturaDetallePromedio(int facturaId)
        {
            return 0;
        }
    }
}
