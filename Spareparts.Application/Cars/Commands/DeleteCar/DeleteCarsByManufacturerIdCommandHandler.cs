
using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Cars.Commands.DeleteCar;
public class DeleteCarsByManufacturerIdCommandHandler(ILogger<DeleteCarsByManufacturerIdCommandHandler> logger, ICarRepository carRepository) : IRequestHandler<DeleteCarsByManufacturerIdCommand, bool> {
    public async Task<bool> Handle(DeleteCarsByManufacturerIdCommand request, CancellationToken cancellationToken) {
        var isDeleted = await carRepository.DeleteCarsByManufacturerId(request.Id);
        if (isDeleted == false) {
            return false;
        }
        else {
            await carRepository.SaveChanges();
            return true;
        }
    }
}
