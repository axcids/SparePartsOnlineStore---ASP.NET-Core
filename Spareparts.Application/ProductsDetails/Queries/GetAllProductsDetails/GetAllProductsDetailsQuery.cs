using MediatR;
using Spareparts.Application.ProductsDetails.Dtos;

namespace Spareparts.Application.ProductsDetails.Queries.GetAllProductsDetails; 
public class GetAllProductsDetailsQuery : IRequest<IEnumerable<ProductsDetailsDtos>>{}
