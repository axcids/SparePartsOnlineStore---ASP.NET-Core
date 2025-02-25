using Microsoft.EntityFrameworkCore;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;

namespace Spareparts.Infrastructure.Repositories;
internal class CategoryRepository(SparepartsDbContext dbContext) : ICategoryRepository {
    public async Task<Guid> AddNewCategory(Category entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> DeleteCategory(Guid CategoryId) {
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
}
