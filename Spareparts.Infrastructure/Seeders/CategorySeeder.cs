﻿using Spareparts.Domain.Entities;
using Spareparts.Infrastructure.Persistence;
using System.ComponentModel;


namespace Spareparts.Infrastructure.Seeders;
internal class CategorySeeder(SparepartsDbContext dbContext) : ICategorySeeder {
    public async Task Seed() {
        if (await dbContext.Database.CanConnectAsync()) {
            if (!dbContext.categories.Any()) {
                var categories = GetCategories();
                dbContext.AddRange(categories);
                await dbContext.SaveChangesAsync();

            }
        }
    }
    private IEnumerable<Category> GetCategories() {
        List<Category> categories = [
            new(){
                Name = "Engine",
                Description = "",
                CreatedAt = DateTime.Now,
                UpdatedAt = null,
            },
            new(){
                Name = "Break",
                Description = "",
                CreatedAt = DateTime.Now,
                UpdatedAt = null,

            }
        ];   
        return categories;
    }
}
