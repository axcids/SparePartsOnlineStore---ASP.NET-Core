using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spareparts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spareparts.Infrastructure.Persistence; 
public class SparepartsDbContext : DbContext{

    public SparepartsDbContext(DbContextOptions<SparepartsDbContext> options) : base(options) {}
    internal DbSet<ProductDetails> ProductsDetails { get; set; }
    internal DbSet<Car> Cars{ get; set; }
    internal DbSet<Category> categories { get; set; }
    internal DbSet<Manufacturer> Manufacturers { get; set; }
    internal DbSet<Supplier> Suppliers{ get; set; }
    internal DbSet<CarProduct> CarsProducts{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);


        // Configure the ProductDetails entity in the model
        modelBuilder.Entity<ProductDetails>(entity =>
        {

            // ----- Indexes -----
            // Create a non-unique index on ManufacturerId
            // Create a non-unique index on CategoryId
            entity.HasIndex(e => e.CategoryId, "IX_ProductDetails_CategoryId").IsUnique(false);
            entity.HasIndex(e => e.SupplierId, "IX_ProductDetails_SupplierId").IsUnique(false);

            // ----- Required/Non-Nullable Properties -----
            entity.Property(e => e.Name).IsRequired();                       // Name cannot be NULL
            entity.Property(e => e.Description).IsRequired();                // Description cannot be NULL
            entity.Property(e => e.UPC).IsRequired();                        // UPC cannot be NULL
            entity.Property(e => e.CategoryId).IsRequired();                 // CategoryId cannot be NULL
            entity.Property(e => e.SupplierId).IsRequired();                 // SupplierIdcannot be NULL
            entity.Property(e => e.Price).IsRequired();                      // Price cannot be NULL
            entity.Property(e => e.WeightInKg).IsRequired();                 // WeightInKg cannot be NULL
            entity.Property(e => e.Dimensions).IsRequired();                 // Dimensions cannot be NULL
            entity.Property(e => e.Material).IsRequired();                   // Material cannot be NULL
            entity.Property(e => e.HasWarranty).IsRequired();                // HasWarranty cannot be NULL
            entity.Property(e => e.WarrantyPeriodInMonths).IsRequired();     // WarrantyPeriodInMonths cannot be NULL

            // Set property column type
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            // ----- Relationships (Foreign Keys) -----
            // Many ProductDetails can reference the same Category
            entity.HasOne(e => e.Category)
                .WithMany(p => p.ProductsDetails)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure the Car entity in the model
        modelBuilder.Entity<Car>(entity => {
            // ----- Indexes -----
            // Create a non-unique index on ManufacturerId
            entity.HasIndex(e => e.ManufacturerId, "IX_Car_ManufacturerId").IsUnique(false);
            // ----- Required/Non-Nullable Properties -----
            entity.Property(e => e.Model).IsRequired();     // Model cannot be NULL
            entity.Property(e => e.ModelYear).IsRequired(); // ModelYear cannot be NULL
            // ----- Relationships (Foreign Keys) -----
            // Many Cars can reference the same Manufacturer
            entity.HasOne(e => e.Manufacturers)
                .WithMany(p => p.Cars)
                .HasForeignKey(e => e.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        // Configure the Category entity in the model
        modelBuilder.Entity<Category>(entity => {
            // ----- Required/Non-Nullable Properties -----
            entity.Property(e => e.Name).IsRequired();  // Name cannot be NULL
        });
        // Configure the Manufacturer entity in the model
        modelBuilder.Entity<Manufacturer>(entity => {
            // ----- Required/Non-Nullable Properties -----
            entity.Property(e => e.Name).IsRequired();  // Name cannot be NULL 
        });
        modelBuilder.Entity<Supplier>(entity => {
            // ----- Required/Non-Nullable Properties 
            entity.Property(e => e.Id).IsRequired();
        });
        modelBuilder.Entity<CarProduct>(entity => {
            // ----- Indexes -----
            // Create a non-unique index on car id
            entity.HasIndex(e => e.CarId, "IX_CarProduct_Car").IsUnique(false);
            // ----- Required/Non-Nullable Properties -----
            entity.Property(e => e.CarId).IsRequired();
            // Create a non-unique index on product id
            entity.HasIndex(e => e.ProductId, "IX_CarProduct_ProductDetails").IsUnique(false);
            // ----- Required/Non-Nullable Properties -----
            entity.Property(e => e.ProductId).IsRequired();
            // ----- Relationships (Foreign Keys) -----
            entity.HasOne(x => x.Car).WithMany(p => p.CarsProducts).HasForeignKey(b => b.CarId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.ProductDetails).WithMany(p => p.CarsProducts).HasForeignKey(b => b.ProductId).OnDelete(DeleteBehavior.Restrict);
            
        });
        modelBuilder.Entity<Supplier>(entity => {
            // ----- Required/Non-Nullable Properties -----
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.SupplierCode).IsRequired();
            entity.Property(e => e.SupplierType).IsRequired();
            entity.Property(e => e.ContactEmail).IsRequired();
            entity.Property(e => e.ContactPhone).IsRequired();
            entity.Property(e => e.AddressLine1).IsRequired();
            entity.Property(e => e.City).IsRequired();
            entity.Property(e => e.StateOrProvince).IsRequired();
            entity.Property(e => e.PostalCode).IsRequired();
            entity.Property(e => e.Country).IsRequired();
           
        });
        modelBuilder.Entity<SupplierProduct>(entity => {
            // ----- Indexes -----
            entity.HasIndex(p => p.SupplierId, "IX_SupplierProduct_SupplierId").IsUnique();
            entity.HasIndex(p => p.ProductId, "IX_SupplierProduct_ProductDetails").IsUnique();
            // ----- Required/Non-Nullable Properties -----
            entity.Property(y => y.SupplierId).IsRequired();
            entity.Property(y => y.ProductId).IsRequired();
            // ----- Relationships (Foreign Keys) -----
            entity.HasOne(x => x.Supplier).WithMany(p => p.SupplierProducts).HasForeignKey(x => x.SupplierId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(x => x.ProductDetails).WithMany(p => p.SupplierProdouct).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);



        });
        


    }
}
