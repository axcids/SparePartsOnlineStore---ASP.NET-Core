using MediatR;
using Spareparts.Application.Products.Dtos;

namespace Spareparts.Application.Products.Queries.GetAllProducts; 
public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>{}
