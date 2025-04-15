using MediatR;
using Spareparts.Application.Cars.Dtos;

namespace Spareparts.Application.Cars.Commands.UpdateCarNameCommand; 
public class UpdateCarModelCommand : IRequest<CarsDtos>{
    public Guid Id { get; set; }
    public string Model { get; set; }

}
