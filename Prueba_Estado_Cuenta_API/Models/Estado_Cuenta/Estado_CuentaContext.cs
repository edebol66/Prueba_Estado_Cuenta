using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prueba_Estado_Cuenta_API.Models.Estado_Cuenta
{
    public partial class Estado_CuentaContext : DbContext
    {
        public Estado_CuentaContext()
        {
        }

        public Estado_CuentaContext(DbContextOptions<Estado_CuentaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<ConfiguracionPorcentaje> ConfiguracionPorcentajes { get; set; } = null!;
        public virtual DbSet<Cuentum> Cuenta { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Tarjetum> Tarjeta { get; set; } = null!;
        public virtual DbSet<TipoCuentum> TipoCuenta { get; set; } = null!;
        public virtual DbSet<TipoTarjetum> TipoTarjeta { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__3DD0A8CB2E80E0C1");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompras)
                    .HasName("PK__Compra__ABA1E89707AB6516");

                entity.ToTable("Compra");

                entity.Property(e => e.IdCompras).HasColumnName("Id_Compras");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Compra");

                entity.Property(e => e.IdCuenta).HasColumnName("Id_Cuenta");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Cuenta");
            });

            modelBuilder.Entity<ConfiguracionPorcentaje>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracionPorcentajes)
                    .HasName("PK__Configur__F0073C3FE26713AB");

                entity.ToTable("Configuracion_Porcentajes");

                entity.Property(e => e.IdConfiguracionPorcentajes).HasColumnName("Id_Configuracion_Porcentajes");

                entity.Property(e => e.NombreConfiguracion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.HasKey(e => e.IdCuenta)
                    .HasName("PK__Cuenta__462699D860598D62");

                entity.HasIndex(e => e.NumeroCuenta, "UQ__Cuenta__D36A7DF8E8BE2445")
                    .IsUnique();

                entity.Property(e => e.IdCuenta).HasColumnName("Id_Cuenta");

                entity.Property(e => e.FechaCuenta)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Cuenta");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.IdTipoCuenta).HasColumnName("Id_Tipo_Cuenta");

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Cuenta");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Cliente");

                entity.HasOne(d => d.IdTipoCuentaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdTipoCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_TipoCuenta");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pago__3E79AD9AE7C8C972");

                entity.ToTable("Pago");

                entity.Property(e => e.IdPago).HasColumnName("Id_Pago");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Pago");

                entity.Property(e => e.IdCuenta).HasColumnName("Id_Cuenta");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_Cuenta");
            });

            modelBuilder.Entity<Tarjetum>(entity =>
            {
                entity.HasKey(e => e.IdTarjeta)
                    .HasName("PK__Tarjeta__F5762032634443EC");

                entity.Property(e => e.IdTarjeta).HasColumnName("Id_Tarjeta");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion");

                entity.Property(e => e.IdCuenta).HasColumnName("Id_Cuenta");

                entity.Property(e => e.IdTipoTarjeta).HasColumnName("Id_Tipo_Tarjeta");

                entity.Property(e => e.NumeroTarjeta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Tarjeta");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tarjeta_Cuenta");

                entity.HasOne(d => d.IdTipoTarjetaNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdTipoTarjeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tarjeta_TipoTarjeta");
            });

            modelBuilder.Entity<TipoCuentum>(entity =>
            {
                entity.HasKey(e => e.IdTipoCuenta)
                    .HasName("PK__Tipo_Cue__ED0B06DD7A23DC6C");

                entity.ToTable("Tipo_Cuenta");

                entity.Property(e => e.IdTipoCuenta).HasColumnName("Id_Tipo_Cuenta");

                entity.Property(e => e.TipoCuenta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Cuenta");
            });

            modelBuilder.Entity<TipoTarjetum>(entity =>
            {
                entity.HasKey(e => e.IdTipoTarjeta)
                    .HasName("PK__Tipo_tar__1705F371C2AF1C6B");

                entity.ToTable("Tipo_tarjeta");

                entity.Property(e => e.IdTipoTarjeta).HasColumnName("Id_Tipo_Tarjeta");

                entity.Property(e => e.TipoTarjeta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Tarjeta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
