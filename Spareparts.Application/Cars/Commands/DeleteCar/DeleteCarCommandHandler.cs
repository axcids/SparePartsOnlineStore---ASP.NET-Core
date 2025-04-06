using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Cars.Commands.DeleteCar;
public class DeleteCarCommandHandler(ILogger<DeleteCarCommandHandler> logger, ICarRepository carRepository) : IRequestHandler<DeleteCarCommand, bool> {
    public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken) {
        var car = await carRepository.GetCarById(request.Id);
        if (car == null) {
            return false;
        }
        else {
            await carRepository.DeleteCarById(car.Id);
            return true;
        }
    }
}
