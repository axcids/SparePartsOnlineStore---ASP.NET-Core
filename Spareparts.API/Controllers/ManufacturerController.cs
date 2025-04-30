using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Categories.Commands.CreateNewCategory;
using Spareparts.Application.Manufacturers.Commands.CreateNewManufacturerCommand;
using Spareparts.Application.Manufacturers.Commands.DeleteManufacturerByIdCommand;
using Spareparts.Application.Manufacturers.Queries;
using Spareparts.Application.Manufacturers.Queries.GetAllManufacturer;

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
    #region DELETE
    [HttpDelete]
    [Route("DeleteManufacturerById")]
    public async Task<IActionResult> DeleteManufacturerById([FromQuery] Guid id) {
        var isDeleted = await mediator.Send(new DeleteManufacturerByIdCommand(id));
        if (isDeleted) {
            return Ok($"Manufacturer with ID {id} deleted successfully.");
        }
        else {
            return NotFound($"Manufacturer with ID {id} not found.");
        }
    }

    #endregion
}
