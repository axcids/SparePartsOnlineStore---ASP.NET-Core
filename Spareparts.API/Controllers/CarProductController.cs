using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Cars.Commands.CreateCar;
using Spareparts.Domain.Entities;

namespace Spareparts.API.Controllers;
[ApiController]
[Route("api/carproduct/")]
public class CarProductController (IMediator mediator) : Controller {

    #region POST
    [HttpPost]
    [Route("AddNewCarProduct")]
    public async Task<IActionResult> AddNewCarProduct([FromBody] CreateCarCommand command) {
        var id = await mediator.Send(command);
        if(id != default(Guid)) return Ok(id);
        return null;
    }

    #endregion

    #region GET
    [HttpGet]
    [Route("GetAllCarProduct")]
    public async Task<IActionResult> GetAllCarProduct() {
        var AllCarProduct = await mediator.Send(Request.Query);
        return Ok(AllCarProduct);
    }

    #endregion
}
