using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    public partial class PeliculasConConteos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql(@"CREATE VIEW [dbo].[PeliculasConConteos]
AS
Select Id, Titulo,
(Select count(*)
from GeneroPelicula
WHERE PeliculasId = Peliculas.Id) as CantidadGeneros,
(Select count(distinct CineId)
FROM PeliculaSalaDeCine
INNER JOIN SalaDeCines
ON SalaDeCines.Id = PeliculaSalaDeCine.SalaDeCineId
WHERE PeliculasId = Peliculas.Id) as CantidadCines,
(
Select count(*)
FROM PeliculasActores
where PeliculaId = Peliculas.Id) as CantidadActores
FROM Peliculas
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[PeliculasConConteos]");
        }
    }
}
