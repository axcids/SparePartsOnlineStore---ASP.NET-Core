using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Categories.Commands.CreateNewCategory;
public class CreateNewCategoryCommandHandler(ICategoryRepository categoryRepository, ILogger<CreateNewCategoryCommandHandler> logger) : IRequestHandler<CreateNewCategoryCommand, Guid> {
    public async Task<Guid> Handle(CreateNewCategoryCommand request, CancellationToken cancellationToken) {
        var entity = new Category {
            Name = request.Name,
            Description = request.Description,
        };
        var id = await categoryRepository.AddNewCategory(entity);
        return id;
    }
}
