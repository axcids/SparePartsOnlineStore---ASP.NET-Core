using MediatR;
using Spareparts.Application.Categories.Dtos;

namespace Spareparts.Application.Categories.Queries.GetAllCategories; 
public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoriesDtos>> {}
