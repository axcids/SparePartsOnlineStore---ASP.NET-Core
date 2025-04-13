using MediatR;
using Spareparts.Application.Manufacturers.Dtos;

namespace Spareparts.Application.Manufacturers.Queries; 
public class GetAllManufacturersQuery : IRequest<IEnumerable<ManufacturersDtos>>{}
