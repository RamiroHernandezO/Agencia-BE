using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Data.Agencia
{
    public partial class AgenciaContext : DbContext
    {
        public AgenciaContext()
        {
        }

        public AgenciaContext(DbContextOptions<AgenciaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entrega> Entregas { get; set; }
        public virtual DbSet<Refaccion> Refacciones { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<ServicioRefaccion> ServicioRefacciones { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=FRIJOLITO\\SQLExpress;Initial Catalog=AgenciaAutomoviles;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entrega>().HasKey(e => e.Id);
            modelBuilder.Entity<Refaccion>().HasKey(r => r.Id);
            modelBuilder.Entity<Rol>().HasKey(r => r.Id);
            modelBuilder.Entity<ServicioRefaccion>().HasKey(sr => sr.Id);
            modelBuilder.Entity<Servicio>().HasKey(s => s.Id);
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Vehiculo>().HasKey(v => v.Id);

            modelBuilder.Entity<Entrega>().Property(e => e.Id).HasColumnName("ServicioID");
            modelBuilder.Entity<Refaccion>().Property(r => r.Id).HasColumnName("RefaccionID");
            modelBuilder.Entity<Rol>().Property(r => r.Id).HasColumnName("RolID");
            modelBuilder.Entity<ServicioRefaccion>().Property(sr => sr.Id).HasColumnName("ServicioID");
            modelBuilder.Entity<Servicio>().Property(s => s.Id).HasColumnName("ServicioID");
            modelBuilder.Entity<Usuario>().Property(u => u.Id).HasColumnName("UsuarioID");
            modelBuilder.Entity<Vehiculo>().Property(v => v.Id).HasColumnName("VehiculoID");

            modelBuilder.Entity<Entrega>()
                .HasOne<Usuario>(e => e.Usuario)
                .WithMany(u => u.Entregas)
                .HasForeignKey(e => e.AdminID)
                .OnDelete(DeleteBehavior.Restrict) 
                .HasConstraintName("FK_Entregas_Administradores");

            modelBuilder.Entity<Servicio>()
                .HasOne<Vehiculo>(s => s.Vehiculo)
                .WithMany(v => v.Servicios)
                .HasForeignKey(s => s.VehiculoID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Servicio_Vehiculos");

            modelBuilder.Entity<ServicioRefaccion>()
                .HasOne<Servicio>(sr => sr.Servicio)
                .WithMany(s => s.ServicioRefacciones)
                .HasForeignKey(sr => sr.Id)
                .OnDelete(DeleteBehavior.Restrict) 
                .HasConstraintName("FK_ServicioRefacciones_Servicios");

            modelBuilder.Entity<ServicioRefaccion>()
                .HasOne<Refaccion>(sr => sr.Refaccion)
                .WithMany(r => r.ServicioRefacciones)
                .HasForeignKey(sr => sr.RefaccionID)
                .OnDelete(DeleteBehavior.Restrict) 
                .HasConstraintName("FK_ServicioRefacciones_Refacciones");

            modelBuilder.Entity<Usuario>()
                .HasOne<Rol>(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Usuarios_Roles");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
