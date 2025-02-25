using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface ICategoryRepository {

    // Add new category 
    Task<Guid> AddNewCategory(Category entity);

    // Delete a category
    Task<bool> DeleteCategory(Guid CategoryId);

    // Update category

    // Fetching all category
    Task<IEnumerable<Category>> GetAllCategories();



}
