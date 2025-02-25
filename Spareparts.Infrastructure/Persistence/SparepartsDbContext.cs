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

    public SparepartsDbContext(DbContextOptions<SparepartsDbContext> options)
       : base(options) {
    }
    internal DbSet<ProductDetails> ProductsDetails { get; set; }
    internal DbSet<Car> Cars{ get; set; }
    internal DbSet<Category> categories { get; set; }
    internal DbSet<Manufacturer> Manufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        // Configure the ProductDetails entity in the model
        modelBuilder.Entity<ProductDetails>(entity => {

            // ----- Indexes -----
            // Create a non-unique index on ManufacturerId
            entity.HasIndex(e => e.ManufacturerId, "IX_ProductDetails_ManufacturerId").IsUnique(false);
            // Create a non-unique index on CategoryId
            entity.HasIndex(e => e.CategoryId, "IX_ProductDetails_CategoryId").IsUnique(false);

            // ----- Required/Non-Nullable Properties -----
            entity.Property(e => e.Name).IsRequired();                       // Name cannot be NULL
            entity.Property(e => e.Description).IsRequired();                // Description cannot be NULL
            entity.Property(e => e.UPC).IsRequired();                        // UPC cannot be NULL
            entity.Property(e => e.ManufacturerId).IsRequired();             // ManufacturerId cannot be NULL
            entity.Property(e => e.CategoryId).IsRequired();                 // CategoryId cannot be NULL
            entity.Property(e => e.Price).IsRequired();                      // Price cannot be NULL
            entity.Property(e => e.WeightInKg).IsRequired();                 // WeightInKg cannot be NULL
            entity.Property(e => e.Dimensions).IsRequired();                 // Dimensions cannot be NULL
            entity.Property(e => e.Material).IsRequired();                   // Material cannot be NULL
            entity.Property(e => e.HasWarranty).IsRequired();                // HasWarranty cannot be NULL
            entity.Property(e => e.WarrantyPeriodInMonths).IsRequired();     // WarrantyPeriodInMonths cannot be NULL

            // ----- Relationships (Foreign Keys) -----
            // Many ProductDetails can reference the same Manufacturer
            entity.HasOne(e => e.Manufacturers)
                  .WithMany(p => p.ProductsDetails)
                  .HasForeignKey(e => e.ManufacturerId);

            // Many ProductDetails can reference the same Category
            entity.HasOne(e => e.Category)
                  .WithMany(p => p.ProductsDetails)
                  .HasForeignKey(e => e.CategoryId);
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
                .HasForeignKey(e => e.ManufacturerId);
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
        

    }
}
