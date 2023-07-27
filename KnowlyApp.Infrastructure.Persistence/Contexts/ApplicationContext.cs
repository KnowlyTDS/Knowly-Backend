using Microsoft.EntityFrameworkCore;
using KnowlyApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KnowlyApp.core.Domain.Entities;

namespace KnowlyApp.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        

        public DbSet<Usuario> Usuario { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables

            modelBuilder.Entity<Usuario>()
                .ToTable("Sis_Usuario");

            #endregion

            #region "primary keys"

            modelBuilder.Entity<Usuario>()
               .HasKey(f => f.Id);
            #endregion

            #region "Relationships"

            
           // modelBuilder.Entity<Propiedad>()
           //.HasMany<Favorita>(f => f.favorita)
           //.WithOne(P => P.propiedad)
           //.HasForeignKey(p => p.IdPropiedad)
           //.OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region "Property configurations"

            #region Usuario
            modelBuilder.Entity<Usuario>().
              Property(c => c.Nombre)
              .IsRequired();

            modelBuilder.Entity<Usuario>().
             Property(c => c.Apellido)
             .IsRequired();

            modelBuilder.Entity<Usuario>().
             Property(c => c.RolId)
             .IsRequired();

            modelBuilder.Entity<Usuario>().
             Property(c => c.Clave)
             .IsRequired();

            #endregion

            #endregion

        }

    }
}
