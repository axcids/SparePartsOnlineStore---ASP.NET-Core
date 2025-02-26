using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Cars.Commands.CreateCar;

namespace Spareparts.API.Controllers; 
[ApiController]
[Route("api/car/")]
public class CarController(IMediator medator) : Controller {
    #region POST 
    [HttpPost]
    [Route("AddNewCar")]
    public async Task<IActionResult> AddNewCar([FromBody] CreateCarCommand command) {
        var id = await medator.Send(command);
        if(id != default(Guid)) return Ok(id);
        return null;
    }

    #endregion
}