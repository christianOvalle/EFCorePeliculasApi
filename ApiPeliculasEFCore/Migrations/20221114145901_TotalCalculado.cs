using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    public partial class TotalCalculado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "FacturaDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "FacturaDetalles",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                computedColumnSql: "precio * Cantidad");

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "FacturaDetalles");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "FacturaDetalles");

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
        }
    }
}
