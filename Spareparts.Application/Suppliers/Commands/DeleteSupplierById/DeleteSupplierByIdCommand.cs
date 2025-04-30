using MediatR;

namespace Spareparts.Application.Suppliers.Commands.DeleteSupplierById; 
public class DeleteSupplierByIdCommand (Guid Id) : IRequest<bool>{
    public Guid Id { get; set; }
}
