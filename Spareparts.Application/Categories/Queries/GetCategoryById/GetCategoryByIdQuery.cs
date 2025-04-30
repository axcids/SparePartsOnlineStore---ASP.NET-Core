using MediatR;
using Spareparts.Application.Categories.Dtos;

namespace Spareparts.Application.Categories.Queries.GetCategoryById; 
public class GetCategoryByIdQuery (Guid Id) : IRequest<CategoriesDtos>{

    public Guid Id { get; set; }

}
