using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Entidades.Seeding
{
    public class SeedingFacturas
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var factura1 = new Factura() { Id = 2, FechaCreacion = new DateTime(2022, 1, 24) };

            var detalle1 = new List<FacturaDetalle>()
    {
        new FacturaDetalle(){Id = 3, FacturaId = factura1.Id, precio = 350.99m},
        new FacturaDetalle(){Id = 4, FacturaId = factura1.Id, precio = 10},
        new FacturaDetalle(){Id = 5, FacturaId = factura1.Id, precio = 45.50m},
    };

            var factura2 = new Factura() { Id = 3, FechaCreacion = new DateTime(2022, 1, 24) };

            var detalle2 = new List<FacturaDetalle>()
    {
        new FacturaDetalle(){Id = 6, FacturaId = factura2.Id, precio = 17.99m},
        new FacturaDetalle(){Id = 7, FacturaId = factura2.Id, precio = 14},
        new FacturaDetalle(){Id = 8, FacturaId = factura2.Id, precio = 45},
        new FacturaDetalle(){Id = 9, FacturaId = factura2.Id, precio = 100},
    };

            var factura3 = new Factura() { Id = 4, FechaCreacion = new DateTime(2022, 1, 24) };

            var detalle3 = new List<FacturaDetalle>()
    {
        new FacturaDetalle(){Id = 10, FacturaId = factura3.Id, precio = 371},
        new FacturaDetalle(){Id = 11, FacturaId = factura3.Id, precio = 114.99m},
        new FacturaDetalle(){Id = 12, FacturaId = factura3.Id, precio = 425},
        new FacturaDetalle(){Id = 13, FacturaId = factura3.Id, precio = 1000},
        new FacturaDetalle(){Id = 14, FacturaId = factura3.Id, precio = 5},
        new FacturaDetalle(){Id = 15, FacturaId = factura3.Id, precio = 2.99m},
    };

            var factura4 = new Factura() { Id = 5, FechaCreacion = new DateTime(2022, 1, 24) };

            var detalle4 = new List<FacturaDetalle>()
    {
        new FacturaDetalle(){Id = 16, FacturaId = factura4.Id, precio = 50},
    };

            modelBuilder.Entity<Factura>().HasData(factura1, factura2, factura3, factura4);
            modelBuilder.Entity<FacturaDetalle>().HasData(detalle1);
            modelBuilder.Entity<FacturaDetalle>().HasData(detalle2);
            modelBuilder.Entity<FacturaDetalle>().HasData(detalle3);
            modelBuilder.Entity<FacturaDetalle>().HasData(detalle4);
        }
    }
}

