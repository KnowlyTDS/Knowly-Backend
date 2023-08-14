using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowlyApp.Infrastructure.Persistence.Migrations
{
    public partial class Change5Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Cursos");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "EstudiantesCursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EstudiantesCursos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EstudiantesCursos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EstudiantesCursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "EstudiantesCursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "EstudiantesCursos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EstudiantesCursos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EstudiantesCursos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EstudiantesCursos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "EstudiantesCursos");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
