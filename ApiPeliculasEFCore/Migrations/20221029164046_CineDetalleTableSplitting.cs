using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    public partial class CineDetalleTableSplitting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<string>(
                name: "CodigoDeEtica",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Historia",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Misiones",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Valores",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "Historia",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Misiones",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Valores",
                table: "Cines");

            migrationBuilder.AddColumn<string>(
                name: "Moneda",
                table: "SalaDeCines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 1,
                column: "Moneda",
                value: "");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 2,
                column: "Moneda",
                value: "");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 3,
                column: "Moneda",
                value: "");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 4,
                column: "Moneda",
                value: "");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 5,
                column: "Moneda",
                value: "");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 6,
                column: "Moneda",
                value: "");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 7,
                column: "Moneda",
                value: "");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 8,
                column: "Moneda",
                value: "");
        }
    }
}
