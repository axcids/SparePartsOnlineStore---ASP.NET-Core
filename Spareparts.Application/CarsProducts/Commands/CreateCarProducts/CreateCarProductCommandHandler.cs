using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.CarsProducts.Commands.CreateCarProducts;
public class CreateCarProductCommandHandler(ICarProductRepository carProductRepository, ILogger<CreateCarProductCommandHandler> logger) : IRequestHandler<CreateCarProductCommand, Guid> {
    public async Task<Guid> Handle(CreateCarProductCommand request, CancellationToken cancellationToken) {
        var CarProduct = new CarProduct {
            CarId = request.CarId,
            ProductId = request.ProductId,
        };
        var id = await carProductRepository.AddNewCarProduct(CarProduct);
        return id;
    }
}
