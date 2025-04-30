using Microsoft.EntityFrameworkCore;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;
using System.Security.Cryptography.X509Certificates;

namespace Spareparts.Infrastructure.Repositories;
internal class CategoryRepository(SparepartsDbContext dbContext) : ICategoryRepository {
    public async Task<Guid> AddNewCategory(Category entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
    
    public async Task<bool> DeleteCategoryById(Guid CategoryId) {
        var entity = dbContext.categories.FirstOrDefault(x=>x.Id == CategoryId);
        dbContext.Remove(entity);
        var isDeleted = await dbContext.SaveChangesAsync();
        if(isDeleted == 1) {
            return true;
        }
        else {
            return false;
        }
    }

    public async Task<IEnumerable<Category>> GetAllCategories() {
        var allCategories = dbContext.categories.ToList();
        return allCategories;
    }
    public async Task<Category> GetCategoryById(Guid id) {
        var category = await dbContext.categories.FirstOrDefaultAsync(x => x.Id == id);
        return category;
    }
    
    public async Task<Category> UpdateCategorybyId (Guid Id, Category newCategory) {
        // Validate the input car object if necessary
        if (newCategory == null) {
            throw new ArgumentNullException(nameof(newCategory), "New car details cannot be null.");

        }
        var fetchedEntity = await dbContext.categories.FirstOrDefaultAsync(x => x.Id == Id);
        if (fetchedEntity == null) return null;
        fetchedEntity.Name = newCategory.Name;
        fetchedEntity.Description = newCategory.Description;
        fetchedEntity.UpdatedAt = newCategory.UpdatedAt;
        await dbContext.SaveChangesAsync();

        return fetchedEntity;

    }
}
