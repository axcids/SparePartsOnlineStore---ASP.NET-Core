using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Categories.Commands.CreateNewCategory;
using Spareparts.Application.Manufacturers.Commands.CreateNewManufacturerCommand;
using Spareparts.Application.Manufacturers.Commands.DeleteManufacturerByIdCommand;
using Spareparts.Application.Manufacturers.Commands.UpdateManufacturerById;
using Spareparts.Application.Manufacturers.Queries;
using Spareparts.Application.Manufacturers.Queries.GetAllManufacturer;
using Spareparts.Application.Manufacturers.Queries.GetManufacturerById;

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
    [HttpGet]
    [Route("GetManufacturerById")]
    public async Task<IActionResult> GetManufacturerById (Guid id) {
        var entity = mediator.Send(new GetManufacturerByIdQuery(id));
        return Ok(entity);
    }
    #endregion
    #region UPDATE 
    [HttpPatch]
    [Route("UpdateManufacturerById")]
    public async Task<IActionResult> UpdateManufacturerById(Guid id, [FromBody] UpdateManufacturerByIdCommand command) {
        command.Id = id; // Set the ID in the command object
        var isUpdated = await mediator.Send(command);
        if (isUpdated != null) {
            return Ok("Manufacturer updated successfully.");
        }
        else {
            return NotFound("Manufacturer not found.");
        }
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
