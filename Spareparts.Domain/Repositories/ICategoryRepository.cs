using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface ICategoryRepository {

    // Add new category 
    Task<Guid> AddNewCategory(Category entity);

    // Delete a category
    Task DeleteCategory(Category entity);

    // Update category

    // Fetching all category
    Task<IEnumerable<Category>> GetAllCategories();



}
