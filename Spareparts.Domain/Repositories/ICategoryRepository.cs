using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface ICategoryRepository {

    // Add new category 
    Task<Guid> AddNewCategory(Category entity);

    // Delete a category
    Task<bool> DeleteCategoryById(Guid CategoryId);

    // Update category

    // Fetching all category
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(Guid id);
    Task<Category> UpdateCategorybyId(Guid Id, Category newCategory);



}
