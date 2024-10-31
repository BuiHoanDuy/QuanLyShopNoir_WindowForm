using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyNoir_BTL.Models;

public partial class ShopNoirTestContext : DbContext
{
    public ShopNoirTestContext()
    {
        this.Database.SetCommandTimeout(120); // 120 giây
    }

    public ShopNoirTestContext(DbContextOptions<ShopNoirTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<ContactHistory> ContactHistories { get; set; }

    public virtual DbSet<CustomerReview> CustomerReviews { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductColor> ProductColors { get; set; }

    public virtual DbSet<UserAddress> UserAddresses { get; set; }

    public virtual DbSet<ProductColorView> ProductColorViews { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-2L3R0R91\\MYCOMPUTER_DUY;Database=ShopNoir_Test;Trusted_Connection=True;TrustServerCertificate=true;Connection Timeout=120;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accounts__3213E83FB292F3AA");

            entity.HasIndex(e => e.Email, "UQ__Accounts__AB6E6164954CBCE5").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carts__3213E83F2D5CD434");

            entity.HasIndex(e => new { e.AccountId, e.ProductId }, "unique_account_product").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("added_at");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Account).WithMany(p => p.Carts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carts__account_i__7C4F7684");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carts__product_i__7D439ABD");
        });

        modelBuilder.Entity<ContactHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contact___3213E83FC9868C32");

            entity.ToTable("Contact_History");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ContactDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("contact_date");
            entity.Property(e => e.ContactDetails).HasColumnName("contact_details");

            entity.HasOne(d => d.Account).WithMany(p => p.ContactHistories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contact_H__accou__02084FDA");
        });

        modelBuilder.Entity<CustomerReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83F07796A25");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Vote).HasColumnName("vote");

            entity.HasOne(d => d.Account).WithMany(p => p.CustomerReviews)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__CustomerR__accou__6A30C649");

            entity.HasOne(d => d.Product).WithMany(p => p.CustomerReviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__CustomerR__produ__6B24EA82");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoices__3213E83F06628D35");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CheckoutMethod).HasColumnName("checkout_method");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ShippingMethod).HasColumnName("shipping_method");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Account).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoices__accoun__6FE99F9F");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceId, e.ProductId }).HasName("PK__InvoiceD__B1FDDA96A7CD1879");

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("fk_invoice");

            entity.HasOne(d => d.Product).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83F594E767A");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Hei)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("hei");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProdDesc).HasColumnName("prod_desc");
            entity.Property(e => e.ProdName)
                .HasMaxLength(255)
                .HasColumnName("prod_name");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Wid)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("wid");
        });

        modelBuilder.Entity<ProductColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__3213E83FF4662B64");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColorCode)
                .HasMaxLength(7)
                .HasColumnName("color_code");
            entity.Property(e => e.ColorName)
                .HasMaxLength(255)
                .HasColumnName("color_name");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.Inventory).HasColumnName("inventory");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductColors)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ProductCo__produ__778AC167");
        });

        modelBuilder.Entity<UserAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserAddr__3213E83FED9FA327");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Address).HasColumnName("address");

            entity.HasOne(d => d.Account).WithMany(p => p.UserAddresses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UserAddre__accou__6383C8BA");
        });

        modelBuilder.Entity<ProductColorView>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("ProductColorView"); // Name of the SQL view created in the database
            entity.Property(e => e.ProductId).HasColumnName("ProductId");
            entity.Property(e => e.ProdName).HasColumnName("prod_name");
            entity.Property(e => e.Price).HasColumnName("Price");
            entity.Property(e => e.Type).HasColumnName("Type");
            entity.Property(e => e.Wid).HasColumnName("Wid");
            entity.Property(e => e.Hei).HasColumnName("Hei");
            entity.Property(e => e.ProductColorId).HasColumnName("ProductColorId");
            entity.Property(e => e.Inventory).HasColumnName("Inventory");
            entity.Property(e => e.ColorName).HasColumnName("color_name");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.ColorCode).HasColumnName("color_code");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
