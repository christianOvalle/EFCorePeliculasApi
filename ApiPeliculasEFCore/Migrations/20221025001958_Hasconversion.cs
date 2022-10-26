using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    public partial class Hasconversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Generos_Nombre",
                table: "Generos");

            migrationBuilder.AlterColumn<string>(
                name: "TipoSalaDeCine",
                table: "SalaDeCines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "DosDimensiones",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoSalaDeCine",
                value: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 2,
                column: "TipoSalaDeCine",
                value: "TresDimensiones");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 3,
                column: "TipoSalaDeCine",
                value: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 4,
                column: "TipoSalaDeCine",
                value: "TresDimensiones");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 5,
                column: "TipoSalaDeCine",
                value: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 6,
                column: "TipoSalaDeCine",
                value: "TresDimensiones");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 7,
                column: "TipoSalaDeCine",
                value: "CXC");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 8,
                column: "TipoSalaDeCine",
                value: "DosDimensiones");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_Nombre",
                table: "Generos",
                column: "Nombre",
                unique: true,
                filter: "EstaBorrado = 'false'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Generos_Nombre",
                table: "Generos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoSalaDeCine",
                table: "SalaDeCines",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoSalaDeCine",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 2,
                column: "TipoSalaDeCine",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 3,
                column: "TipoSalaDeCine",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 4,
                column: "TipoSalaDeCine",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 5,
                column: "TipoSalaDeCine",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 6,
                column: "TipoSalaDeCine",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 7,
                column: "TipoSalaDeCine",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 8,
                column: "TipoSalaDeCine",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Generos_Nombre",
                table: "Generos",
                column: "Nombre",
                unique: true);
        }
    }
}
