using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    public partial class EjemploOwbed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Direccion_Id",
                table: "Cines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "barrio",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "casa",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Barrio",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Calle",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillingAddress_Id",
                table: "Actores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_barrio",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_casa",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Casa",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DireccionHogar_Id",
                table: "Actores",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Direccion_Id",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "barrio",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "casa",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Barrio",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Calle",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Id",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "BillingAddress_barrio",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "BillingAddress_casa",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "Casa",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "DireccionHogar_Id",
                table: "Actores");
        }
    }
}
