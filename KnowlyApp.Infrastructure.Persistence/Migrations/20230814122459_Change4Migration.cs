using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowlyApp.Infrastructure.Persistence.Migrations
{
    public partial class Change4Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Maestros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "cantCursosImpartidos",
                table: "Maestros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Maestros");

            migrationBuilder.DropColumn(
                name: "cantCursosImpartidos",
                table: "Maestros");
        }
    }
}
