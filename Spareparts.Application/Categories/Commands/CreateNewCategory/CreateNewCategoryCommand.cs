
using MediatR;

namespace Spareparts.Application.Categories.Commands.CreateNewCategory; 
public class CreateNewCategoryCommand : IRequest<Guid> {
    public string Name { get; set; }
    public string? Description { get; set; }

}
