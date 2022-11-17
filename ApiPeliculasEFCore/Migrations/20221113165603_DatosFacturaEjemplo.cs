using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    public partial class DatosFacturaEjemplo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Facturas",
                columns: new[] { "Id", "FechaCreacion" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FacturaDetalles",
                columns: new[] { "Id", "FacturaId", "Producto", "precio" },
                values: new object[,]
                {
                    { 3, 2, null, 350.99m },
                    { 4, 2, null, 10m },
                    { 5, 2, null, 45.50m },
                    { 6, 3, null, 17.99m },
                    { 7, 3, null, 14m },
                    { 8, 3, null, 45m },
                    { 9, 3, null, 100m },
                    { 10, 4, null, 371m },
                    { 11, 4, null, 114.99m },
                    { 12, 4, null, 425m },
                    { 13, 4, null, 1000m },
                    { 14, 4, null, 5m },
                    { 15, 4, null, 2.99m },
                    { 16, 5, null, 50m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FacturaDetalles",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Facturas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
