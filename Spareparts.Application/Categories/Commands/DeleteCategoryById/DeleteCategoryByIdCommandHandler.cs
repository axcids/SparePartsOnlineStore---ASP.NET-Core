using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Categories.Commands.DeleteCategoryById;
public class DeleteCategoryByIdCommandHandler(ICategoryRepository categoryRepository, ILogger<DeleteCategoryByIdCommandHandler> logger) : IRequestHandler<DeleteCategoryByIdCommand, bool> {
    public Task<bool> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken) {
        var isDeleted = categoryRepository.DeleteCategoryById(request.Id);
        if (isDeleted.Result) {
            logger.LogInformation($"Category with ID {request.Id} deleted successfully.");
            return Task.FromResult(true);
        }
        else {
            logger.LogWarning($"Category with ID {request.Id} not found.");
            return Task.FromResult(false);
        }
    }
}
