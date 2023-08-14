using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowlyApp.Infrastructure.Persistence.Migrations
{
    public partial class Change33Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "EstudiantesCursos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "EstudiantesCursos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "EstudiantesCursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "EstudiantesCursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
