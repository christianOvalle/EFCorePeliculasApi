using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPeliculasEFCore.Migrations
{
    public partial class FVT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"CREATE FUNCTION PeliculaConConteos
(
@peliculaId int
)
RETURNS TABLE 
AS
RETURN 
(
-- Add the SELECT statement with parameter references here
SeLeCt Id, Titulo,
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
	where Id = @peliculaId
)");

		}

		protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP FUNCTION [dbo].[PeliculaConConteo]");
		}
    }
}
