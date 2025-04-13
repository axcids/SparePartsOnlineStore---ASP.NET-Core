using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Categories.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Categories.Queries.GetAllCategories;
public class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, ILogger<GetAllCategoriesQueryHandler> logger) : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoriesDtos>> {
    public async Task<IEnumerable<CategoriesDtos>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken) {
        var entities = await categoryRepository.GetAllCategories();
        var entitiesDtos = entities.Select(CategoriesDtos.FromEntity).ToList();
        return entitiesDtos;
    }
}
