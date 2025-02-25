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

    internal DbSet<ProductDetails> ProductsDetails { get; set; }
    internal DbSet<Car> Cars{ get; set; }
    internal DbSet<Category> categories { get; set; }
    internal DbSet<Manufacturer> Manufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductDetails>(entity => {

            //Indexes
            entity.HasIndex(e => e.ManufacturerId, "IX_ProductDetails_ManufacturerId").IsUnique(false);
            entity.HasIndex(e => e.CategoryId, "IX_ProductDetails_CategoryId").IsUnique(false);

            //Requires
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.UPC).IsRequired();
            entity.Property(e => e.Manufacturer).IsRequired();
            entity.Property(e => e.CategoryId).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.WeightInKg).IsRequired();
            entity.Property(e => e.Dimensions).IsRequired();
            entity.Property(e => e.Material).IsRequired();
            entity.Property(e => e.HasWarranty).IsRequired();
            entity.Property(e => e.WarrantyPeriodInMonths).IsRequired();
            //Foreign Keys
            entity.HasOne(e => e.Manufacturer).WithMany(p => p.ProductsDetails).HasForeignKey(e => e.ManufacturerId);   



        });
    }
}
