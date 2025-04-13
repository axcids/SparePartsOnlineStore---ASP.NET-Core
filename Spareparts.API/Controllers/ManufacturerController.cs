using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Categories.Commands.CreateNewCategory;
using Spareparts.Application.Manufacturers.Commands;
using Spareparts.Application.Manufacturers.Queries;

namespace Spareparts.API.Controllers;
[ApiController]
[Route("api/Manufacturer/")]
public class ManufacturerController (IMediator mediator) : Controller {
    #region POST 
    [HttpPost]
    [Route("AddNewManufacturer")]
    public async Task<IActionResult> AddNewManufacturer([FromBody] CreateNewManufacturerCommand command) {
        var id = await mediator.Send(command);
        if(id != default(Guid)) return Ok(id);
        return null;
    }
    #endregion
    #region GET 
    [HttpGet]
    [Route("GetAllManufacturers")]
    public async Task<IActionResult> GetAllManufacturers() {
        var allManufacturers = await mediator.Send(new GetAllManufacturersQuery());
        return Ok(allManufacturers);
    }
    #endregion
}
