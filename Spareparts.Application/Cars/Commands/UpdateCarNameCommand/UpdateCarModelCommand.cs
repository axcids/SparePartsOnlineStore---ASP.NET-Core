using MediatR;
using Spareparts.Application.Cars.Dtos;

namespace Spareparts.Application.Cars.Commands.UpdateCarNameCommand; 
public class UpdateCarModelCommand (Guid id, string newModel) : IRequest<CarsDtos>{
    public Guid Id { get; set; } = id;
    public string Model { get; set; } = newModel;

}
