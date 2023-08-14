﻿// <auto-generated />
using System;
using KnowlyApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KnowlyApp.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230814081809_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Cursos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaestroId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maestrosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("maestrosId");

                    b.ToTable("Cursos", (string)null);
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Entregas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivosAdjuntos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("Comentarios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TareaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("TareaId");

                    b.ToTable("Entregas", (string)null);
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Estudiantes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CantidadTareas")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Estudiantes", (string)null);
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.EstudiantesCursos", b =>
                {
                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.HasKey("EstudianteId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("EstudiantesCursos");
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Maestros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Maestros", (string)null);
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Tareas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaestroId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PuntuacionMaxima")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("estudiantesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("MaestroId");

                    b.HasIndex("estudiantesId");

                    b.ToTable("Tareas", (string)null);
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Cursos", b =>
                {
                    b.HasOne("KnowlyApp.Core.Domain.Entities.Maestros", "maestros")
                        .WithMany("CursosImpartidos")
                        .HasForeignKey("maestrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("maestros");
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Entregas", b =>
                {
                    b.HasOne("KnowlyApp.Core.Domain.Entities.Estudiantes", "estudiantes")
                        .WithMany("entregas")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KnowlyApp.Core.Domain.Entities.Tareas", "tareas")
                        .WithMany("Entregas")
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estudiantes");

                    b.Navigation("tareas");
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.EstudiantesCursos", b =>
                {
                    b.HasOne("KnowlyApp.Core.Domain.Entities.Cursos", "Curso")
                        .WithMany("EstudiantesInscritos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KnowlyApp.Core.Domain.Entities.Estudiantes", "estudiante")
                        .WithMany("Cursos")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("estudiante");
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Tareas", b =>
                {
                    b.HasOne("KnowlyApp.Core.Domain.Entities.Cursos", "curso")
                        .WithMany("Tareas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KnowlyApp.Core.Domain.Entities.Maestros", "Maestro")
                        .WithMany("TareasCalificadas")
                        .HasForeignKey("MaestroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KnowlyApp.Core.Domain.Entities.Estudiantes", "estudiantes")
                        .WithMany()
                        .HasForeignKey("estudiantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maestro");

                    b.Navigation("curso");

                    b.Navigation("estudiantes");
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Cursos", b =>
                {
                    b.Navigation("EstudiantesInscritos");

                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Estudiantes", b =>
                {
                    b.Navigation("Cursos");

                    b.Navigation("entregas");
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Maestros", b =>
                {
                    b.Navigation("CursosImpartidos");

                    b.Navigation("TareasCalificadas");
                });

            modelBuilder.Entity("KnowlyApp.Core.Domain.Entities.Tareas", b =>
                {
                    b.Navigation("Entregas");
                });
#pragma warning restore 612, 618
        }
    }
}
