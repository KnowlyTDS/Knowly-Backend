using KnowlyApp.Core.Domain.Common;
using KnowlyApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowlyApp.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        private DbSet<Estudiantes> Estudiantes { get; set; }
        private DbSet<Maestros> Maestros { get; set; }
        private DbSet<Cursos> Cursos { get; set; }
        private DbSet<Tareas> Tareas { get; set; }
        private DbSet<Entregas> Entregas { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entity in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTime.Now;
                        entity.Entity.CreatedBy = "Default";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region "Tables"

            modelBuilder.Entity<Estudiantes>().ToTable("Estudiantes");
            modelBuilder.Entity<Maestros>().ToTable("Maestros");
            modelBuilder.Entity<Cursos>().ToTable("Cursos");
            modelBuilder.Entity<Tareas>().ToTable("Tareas");
            modelBuilder.Entity<Entregas>().ToTable("Entregas");

            #endregion "Tables"

            #region "Primary Keys"

            modelBuilder.Entity<Estudiantes>().HasKey(e => e.Id);
            modelBuilder.Entity<Maestros>().HasKey(m => m.Id);
            modelBuilder.Entity<Cursos>().HasKey(c => c.Id);
            modelBuilder.Entity<Tareas>().HasKey(t => t.Id);
            modelBuilder.Entity<Entregas>().HasKey(e => e.Id);

            // modelBuilder.Entity<Estudiantes>().HasIndex(e => e.Id).IsUnique();

            #endregion "Primary Keys"

            #region Relationships

            // Relaciones para la entidad Cursos
            modelBuilder.Entity<EstudiantesCursos>()
                .HasKey(ec => new { ec.EstudianteId, ec.CursoId });

            modelBuilder.Entity<Cursos>()
             .HasOne(c => c.maestros)
            .WithMany(m => m.CursosImpartidos)
            .HasForeignKey(c => c.MaestroId);

            modelBuilder.Entity<EstudiantesCursos>()
                .HasOne(ec => ec.estudiante)
                .WithMany(e => e.Cursos)
                .HasForeignKey(ec => ec.EstudianteId);

            modelBuilder.Entity<EstudiantesCursos>()
                .HasOne(ec => ec.Curso)
                .WithMany(c => c.EstudiantesInscritos)
                .HasForeignKey(ec => ec.CursoId);

            // Relaciones para la entidad Entregas
            modelBuilder.Entity<Entregas>()
                .HasOne(e => e.estudiantes)
                .WithMany(est => est.entregas)
                .HasForeignKey(e => e.EstudianteId)
                .OnDelete(DeleteBehavior.Cascade); // Elimina entregas al eliminar un estudiante

            modelBuilder.Entity<Entregas>()
                .HasOne(e => e.tareas)
                .WithMany(t => t.Entregas)
                .HasForeignKey(e => e.TareaId)
                .OnDelete(DeleteBehavior.Restrict); // Restringe eliminación en cascada

            // Relaciones para la entidad Estudiantes
            modelBuilder.Entity<Estudiantes>()
                .HasMany(e => e.entregas)
                .WithOne(entrega => entrega.estudiantes)
                .OnDelete(DeleteBehavior.Cascade); // Considera eliminar en cascada si es apropiado

            // Relaciones para la entidad Maestros
            modelBuilder.Entity<Maestros>()
                .HasMany(m => m.TareasCalificadas)
                .WithOne(t => t.Maestro)
                .OnDelete(DeleteBehavior.Cascade); // Considera eliminar en cascada si es apropiado

            // Relaciones para la entidad Tareas
            modelBuilder.Entity<Tareas>()
                .HasOne(t => t.curso)
                .WithMany(c => c.Tareas)
                .HasForeignKey(t => t.CursoId);

            modelBuilder.Entity<Tareas>()
                .HasOne(t => t.Maestro)
                .WithMany(m => m.TareasCalificadas)
                .HasForeignKey(t => t.MaestroId)
                .OnDelete(DeleteBehavior.Restrict); // Restringe eliminación en cascada

            modelBuilder.Entity<Tareas>()
                .HasMany(t => t.Entregas)
                .WithOne(e => e.tareas)
                .HasForeignKey(e => e.TareaId)
                .OnDelete(DeleteBehavior.Cascade); // Considera eliminar en cascada si es apropiado

            #endregion Relationships

            #region "Properties Configuration"

            modelBuilder.Entity<Tareas>().Property(t => t.Titulo).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Tareas>().Property(t => t.Descripcion).IsRequired();
            modelBuilder.Entity<Tareas>().Property(t => t.FechaCreacion).IsRequired();
            modelBuilder.Entity<Tareas>().Property(t => t.FechaVencimiento).IsRequired();
            modelBuilder.Entity<Tareas>().Property(t => t.PuntuacionMaxima).IsRequired();
            modelBuilder.Entity<Tareas>().Property(t => t.CursoId).IsRequired();
            modelBuilder.Entity<Tareas>().Property(t => t.MaestroId).IsRequired();
            modelBuilder.Entity<Tareas>().Property(t => t.EstudianteId).IsRequired();

            // modelBuilder.Entity<Estudiantes>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Estudiantes>().Property(e => e.Email).IsRequired();
            modelBuilder.Entity<Estudiantes>().Property(e => e.Foto).IsRequired();
            modelBuilder.Entity<Estudiantes>().Property(e => e.CantidadTareas).IsRequired();
            modelBuilder.Entity<Estudiantes>().Property(e => e.Tel).IsRequired();
            modelBuilder.Entity<Estudiantes>().Property(e => e.Nombre).IsRequired();
            modelBuilder.Entity<Estudiantes>().Property(e => e.Apellido).IsRequired();
            modelBuilder.Entity<Estudiantes>().Property(e => e.isActive).IsRequired();

            modelBuilder.Entity<Entregas>().Property(e => e.FechaEntrega).IsRequired();
            modelBuilder.Entity<Entregas>().Property(e => e.ArchivosAdjuntos).IsRequired();
            modelBuilder.Entity<Entregas>().Property(e => e.Calificacion).IsRequired();
            modelBuilder.Entity<Entregas>().Property(e => e.Comentarios).IsRequired();
            modelBuilder.Entity<Entregas>().Property(e => e.EstudianteId).IsRequired();
            modelBuilder.Entity<Entregas>().Property(e => e.TareaId).IsRequired();
            modelBuilder.Entity<Entregas>().Property(e => e.CreatedAt).IsRequired();

            modelBuilder.Entity<Cursos>().Property(c => c.Descripcion).IsRequired();
            modelBuilder.Entity<Cursos>().Property(c => c.Horario).IsRequired();
            modelBuilder.Entity<Cursos>().Property(c => c.MaestroId).IsRequired();

            modelBuilder.Entity<Maestros>().Property(m => m.Especialidad).IsRequired();

            #endregion "Properties Configuration"
        }
    }
}