using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Categories.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, ILogger<GetCategoryByIdQueryHandler> logger) : IRequestHandler<GetCategoryByIdQuery, CategoriesDtos> {
    public async Task<CategoriesDtos> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken) {
        var Entity = await categoryRepository.GetCategoryById(request.Id);
        var EntityDto = CategoriesDtos.FromEntity(Entity);
        return EntityDto;
    }
}
