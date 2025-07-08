using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Categories.Dtos;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Categories.Commands.UpdateCategoryById;
public class UpdateCategoryByIdCommandHandler(ICategoryRepository categoryRepository, ILogger<UpdateCategoryByIdCommandHandler> logger) : IRequestHandler<UpdateCategoryByIdCommand, CategoriesDtos> {
    public async Task<CategoriesDtos> Handle(UpdateCategoryByIdCommand request, CancellationToken cancellationToken) {
        var newEntity = new Category() {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            UpdatedAt = DateTime.Now
        };
        var updatedEntity = await categoryRepository.UpdateCategorybyId(request.Id, newEntity);
        if (updatedEntity == null) {
            logger.LogError("Category with ID {Id} not found.", request.Id);
            throw new KeyNotFoundException($"Category with ID {request.Id} not found.");
            return null;
        }
        else {
            return CategoriesDtos.FromEntity(newEntity);
        }
    }
}
