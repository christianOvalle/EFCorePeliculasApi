using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    public partial class FacturaVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Facturas",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Facturas");

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
    }
}
