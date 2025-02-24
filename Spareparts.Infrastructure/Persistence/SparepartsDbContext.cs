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

    }
}
