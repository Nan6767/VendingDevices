using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using VendingDevices.Entities;

namespace VendingDevices.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
        SeedData.SeedDatabase(this);
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
        SeedData.SeedDatabase(this);
    }

    public virtual DbSet<Check> Checks { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sell> Sells { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=5503;user=root;password=\"+-=()59nan_67%081\";database=champ", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Check>(entity =>
        {
            entity.HasKey(e => e.IdCheck).HasName("PRIMARY");

            entity.ToTable("check");

            entity.HasIndex(e => e.IdDevice, "check_device_FK");

            entity.HasIndex(e => e.IdUser, "check_user_FK");

            entity.Property(e => e.IdCheck).HasColumnName("Id_check");
            entity.Property(e => e.IdDevice).HasColumnName("Id_device");
            entity.Property(e => e.IdUser).HasColumnName("Id_user");
            entity.Property(e => e.InfoCheck).HasColumnType("text");
            entity.Property(e => e.Problems).HasMaxLength(100);

            entity.HasOne(d => d.IdDeviceNavigation).WithMany(p => p.Checks)
                .HasForeignKey(d => d.IdDevice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("check_device_FK");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Checks)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("check_user_FK");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.IdDevice).HasName("PRIMARY");

            entity.ToTable("device");

            entity.Property(e => e.IdDevice).HasColumnName("Id_device");
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.Place).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("product");

            entity.Property(e => e.IdProduct).HasColumnName("Id_product");
            entity.Property(e => e.InfoSell).HasColumnType("text");
            entity.Property(e => e.Information).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.IdRole).HasColumnName("Id_role");
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Sell>(entity =>
        {
            entity.HasKey(e => e.IdSell).HasName("PRIMARY");

            entity.ToTable("sell");

            entity.HasIndex(e => e.IdDevice, "sell_device_FK");

            entity.HasIndex(e => e.IdProduct, "sell_product_FK");

            entity.Property(e => e.IdSell).HasColumnName("Id_sell");
            entity.Property(e => e.DateSell).HasColumnType("datetime");
            entity.Property(e => e.IdDevice).HasColumnName("Id_device");
            entity.Property(e => e.IdProduct).HasColumnName("Id_product");
            entity.Property(e => e.Method).HasMaxLength(100);

            entity.HasOne(d => d.IdDeviceNavigation).WithMany(p => p.Sells)
                .HasForeignKey(d => d.IdDevice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sell_device_FK");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Sells)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sell_product_FK");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.IdRole, "user_role_FK");

            entity.Property(e => e.IdUser).HasColumnName("Id_user");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IdRole)
                .HasMaxLength(100)
                .HasColumnName("Id_role");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Number).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
