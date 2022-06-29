using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class MCastanedaBriveContext : DbContext
    {
        public MCastanedaBriveContext()
        {
        }

        public MCastanedaBriveContext(DbContextOptions<MCastanedaBriveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<SucursalProducto> SucursalProductos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TB0B2SD6; Database= MCastanedaBrive; Trusted_Connection=True; User ID=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__09889210FB8B2396");

                entity.ToTable("Producto");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK__Sucursal__BFB6CD99D4497283");

                entity.ToTable("Sucursal");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSucursal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SucursalProducto>(entity =>
            {
                entity.HasKey(e => e.IdSucursalProducto)
                    .HasName("PK__Sucursal__072D557E5B1DF927");

                entity.ToTable("SucursalProducto");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.SucursalProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__SucursalP__IdPro__31EC6D26");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.SucursalProductos)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK__SucursalP__IdSuc__33D4B598");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
