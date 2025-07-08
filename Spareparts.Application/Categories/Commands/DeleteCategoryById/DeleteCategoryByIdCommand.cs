using MediatR;

namespace Spareparts.Application.Categories.Commands.DeleteCategoryById; 
public class DeleteCategoryByIdCommand (Guid id) : IRequest<bool>{
    public Guid Id { get; set; }

}
