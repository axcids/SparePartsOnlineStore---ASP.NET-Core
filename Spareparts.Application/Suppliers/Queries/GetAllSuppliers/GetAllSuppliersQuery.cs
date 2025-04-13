using MediatR;
using Spareparts.Application.Suppliers.Dtos;

namespace Spareparts.Application.Suppliers.Queries.GetAllSuppliers; 
public class GetAllSuppliersQuery : IRequest<IEnumerable<SuppliersDtos>>{}
