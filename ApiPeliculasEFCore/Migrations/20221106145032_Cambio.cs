using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    public partial class Cambio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaDeCines_Cines_CineId",
                table: "SalaDeCines");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SalaDeCines_Cines_CineId",
                table: "SalaDeCines",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaDeCines_Cines_CineId",
                table: "SalaDeCines");

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CineOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_SalaDeCines_Cines_CineId",
                table: "SalaDeCines",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
