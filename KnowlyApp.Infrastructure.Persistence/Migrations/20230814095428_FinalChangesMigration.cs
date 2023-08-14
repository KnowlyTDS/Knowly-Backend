using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowlyApp.Infrastructure.Persistence.Migrations
{
    public partial class FinalChangesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Maestros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Maestros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Maestros");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Maestros");
        }
    }
}