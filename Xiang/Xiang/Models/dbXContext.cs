using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Xiang.Models
{
    public partial class dbXContext : DbContext
    {
        public dbXContext()
        {
        }

        public dbXContext(DbContextOptions<dbXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertise> Advertises { get; set; } = null!;
        public virtual DbSet<Aorder> Aorders { get; set; } = null!;
        public virtual DbSet<Corder> Corders { get; set; } = null!;
        public virtual DbSet<Coupon> Coupons { get; set; } = null!;
        public virtual DbSet<CouponsLog> CouponsLogs { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Evaluation> Evaluations { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Psite> Psites { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbX;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertise>(entity =>
            {
                entity.ToTable("Advertise");

                entity.Property(e => e.AdvertiseId).HasColumnName("AdvertiseID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Aorder>(entity =>
            {
                entity.ToTable("AOrders");

                entity.Property(e => e.AorderId).HasColumnName("AOrderID");

                entity.Property(e => e.AdvertiseId).HasColumnName("AdvertiseID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Advertise)
                    .WithMany(p => p.Aorders)
                    .HasForeignKey(d => d.AdvertiseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AOrders_Advertise");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Aorders)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AOrders_Suppliers");
            });

            modelBuilder.Entity<Corder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("COrders");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TakeDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Corders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_COrders_Customers");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Corders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_COrders_Products");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.HasIndex(e => e.Code, "UQ_Coupons_Code")
                    .IsUnique();

                entity.Property(e => e.CouponId).HasColumnName("CouponID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CouponsLog>(entity =>
            {
                entity.HasKey(e => e.CouponId);

                entity.ToTable("CouponsLog");

                entity.Property(e => e.CouponId).HasColumnName("CouponID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CouponsLogs)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CouponsLog_COrders");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CreditCard, "UQ_Customers_CreditCard")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ_Customers_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ_Customers_Phone")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Birth).HasColumnType("datetime");

                entity.Property(e => e.BlackListed).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreditCard).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.Property(e => e.EvaluationId).HasColumnName("EvaluationID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Response).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Evaluations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Evaluations_Customers");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Evaluations)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Evaluations_Products");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ_Managers_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ_Managers_Phone")
                    .IsUnique();

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Image, "UQ_Products_Image")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<Psite>(entity =>
            {
                entity.HasKey(e => e.SiteId);

                entity.ToTable("PSite");

                entity.HasIndex(e => e.Image, "UQ_PSite_Image")
                    .IsUnique();

                entity.Property(e => e.SiteId).HasColumnName("SiteID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Psites)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PSite_Products");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ_Suppliers_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ_Suppliers_Phone")
                    .IsUnique();

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
