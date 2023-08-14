using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowlyApp.Infrastructure.Persistence.Migrations
{
    public partial class Changeudate1Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Maestros_maestrosId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_maestrosId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "maestrosId",
                table: "Cursos");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_MaestroId",
                table: "Cursos",
                column: "MaestroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Maestros_MaestroId",
                table: "Cursos",
                column: "MaestroId",
                principalTable: "Maestros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Maestros_MaestroId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_MaestroId",
                table: "Cursos");

            migrationBuilder.AddColumn<int>(
                name: "maestrosId",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_maestrosId",
                table: "Cursos",
                column: "maestrosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Maestros_maestrosId",
                table: "Cursos",
                column: "maestrosId",
                principalTable: "Maestros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
