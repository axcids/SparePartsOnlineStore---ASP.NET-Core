using MediatR;
using Spareparts.Application.Suppliers.Dtos;

namespace Spareparts.Application.Suppliers.Queries.GetSuppliersBySupplierCode; 
public class GetSuppliersBySupplierCodeQuery (string supplierCode) : IRequest<IEnumerable<SuppliersDtos>> {
    public string SupplierCode { get; set; } = supplierCode;

}
