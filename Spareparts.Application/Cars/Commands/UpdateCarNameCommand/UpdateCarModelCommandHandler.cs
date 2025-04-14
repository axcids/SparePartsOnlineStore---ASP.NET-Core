using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Cars.Dtos;
using Spareparts.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Spareparts.Application.Cars.Commands.UpdateCarNameCommand;
public class UpdateCarModelCommandHandler(ICarRepository carRepository, ILogger<UpdateCarModelCommandHandler> logger) : IRequestHandler<UpdateCarModelCommand, CarsDtos> {
    public async Task<CarsDtos> Handle(UpdateCarModelCommand request, CancellationToken cancellationToken) {
        var newEntity = await carRepository.UpdateCarModel(request.Id, request.Model);
        if (newEntity != null) {
            var EntityDto = CarsDtos.FromEntity(newEntity);
            return EntityDto;
        }
        return null;
    }
}
