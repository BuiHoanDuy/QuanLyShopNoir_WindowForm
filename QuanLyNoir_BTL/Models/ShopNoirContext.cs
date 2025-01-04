// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyNoir_BTL.Models;

public partial class ShopNoirContext : DbContext
{
    public ShopNoirContext(DbContextOptions<ShopNoirContext> options)
        : base(options)
    {
    }
    public ShopNoirContext()
    {
    }
    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductColor> ProductColors { get; set; }

    public virtual DbSet<ProductColorSize> ProductColorSizes { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
     => optionsBuilder.UseSqlServer("Server=LAPTOP-2L3R0R91\\MYCOMPUTER_DUY;Database=ShopNoir;Trusted_Connection=True;TrustServerCertificate=true;Connection Timeout=120;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accounts__3213E83F6E296C81");

            entity.HasIndex(e => e.Username, "UQ__Accounts__F3DBC5721126DF2B").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83F681D74E4");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone_number");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoices__3213E83F5914F33B");

            entity.HasIndex(e => e.CreatedAt, "IDX_Invoices_CreatedAt");

            entity.HasIndex(e => e.CreatedBy, "IDX_Invoices_CreatedBy");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoices__create__7ABC33CD");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Invoices__custom__278EDA44");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_Invoices_VoucherId");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceId, e.ProductColorSizeId }).HasName("PK__InvoiceD__802D6C5398B99C3D");

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.ProductColorSizeId).HasColumnName("product_color_size_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK__InvoiceDe__invoi__1387E197");

            entity.HasOne(d => d.ProductColorSize).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.ProductColorSizeId)
                .HasConstraintName("FK__InvoiceDe__produ__147C05D0");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83F6FE66AB4");

            entity.HasIndex(e => e.Type, "IDX_Products_Type");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("height");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProdDesc).HasColumnName("prod_desc");
            entity.Property(e => e.ProdName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("prod_name");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.Width)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("width");
        });

        modelBuilder.Entity<ProductColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__3213E83FA164E155");

            entity.HasIndex(e => e.ProductId, "IDX_ProductColors_ProductId");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ColorCode)
                .HasMaxLength(7)
                .HasColumnName("color_code");
            entity.Property(e => e.ColorName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("color_name");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductColors)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductCo__produ__6E565CE8");
        });

        modelBuilder.Entity<ProductColorSize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__3213E83F11BCA35E");

            entity.HasIndex(e => e.ProductColorId, "IDX_ProductColorSizes_ProductColorId");

            entity.HasIndex(e => e.SizeId, "IDX_ProductColorSizes_SizeId");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Inventory).HasColumnName("inventory");
            entity.Property(e => e.ProductColorId).HasColumnName("product_color_id");
            entity.Property(e => e.SizeId)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("size_id");

            entity.HasOne(d => d.ProductColor).WithMany(p => p.ProductColorSizes)
                .HasForeignKey(d => d.ProductColorId)
                .HasConstraintName("FK__ProductCo__produ__75035A77");

            entity.HasOne(d => d.Size).WithMany(p => p.ProductColorSizes)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK__ProductCo__size___75F77EB0");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sizes__3213E83F69652710");

            entity.HasIndex(e => e.SizeName, "UQ__Sizes__75FCE556D69C57FD").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.SizeName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("size_name");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vouchers__3213E83F5FB020E6");

            entity.HasIndex(e => e.Status, "IDX_Vouchers_Status");

            entity.HasIndex(e => e.Code, "UQ__Vouchers__357D4CF9B2A9F297").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.DiscountType)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("discount_type");
            entity.Property(e => e.DiscountValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount_value");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MaxUsage).HasColumnName("max_usage");
            entity.Property(e => e.MinOrderValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("min_order_value");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.UsedCount)
                .HasDefaultValue(0)
                .HasColumnName("used_count");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}