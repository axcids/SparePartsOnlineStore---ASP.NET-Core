using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Cars.Commands.CreateCar;
using Spareparts.Application.Cars.Commands.DeleteCar;
using Spareparts.Application.Cars.Commands.UpdateCarCommand;
using Spareparts.Application.Cars.Commands.UpdateCarNameCommand;
using Spareparts.Application.Cars.Queries.GetAllCars;
using Spareparts.Application.Cars.Queries.GetCarById;
using Spareparts.Application.Cars.Queries.GetCarsByManufacturerId;
using System.Data;

namespace Spareparts.API.Controllers; 
[ApiController]
[Route("api/car/")]
public class CarController(IMediator meditor) : Controller {
    #region POST 
    [HttpPost]
    [Route("AddNewCar")]
    public async Task<IActionResult> AddNewCar([FromBody] CreateCarCommand command) {
        var id = await meditor.Send(command);
        if(id != default(Guid)) return Ok(id);
        return null;
    }

    #endregion

    #region GET
    [HttpGet]
    [Route("GetAllCars")]
    public async Task<IActionResult> GetAllCars() {
        var allCars = await meditor.Send(new GetAllCarsQuery());
        return Ok(allCars);
    }
    [HttpGet]
    [Route("GetCarById")]
    public async Task<IActionResult> GetCarById(Guid id) {
        var car = await meditor.Send(new GetCarByIdQuery(id));
        if (car != null) return Ok(car);
        return NotFound();
    }
    [HttpGet]
    [Route("GetCarsByManufacturerId")]
    public async Task<IActionResult> GetCarsByManufacturerId(Guid manufacturerId) {
        var allCars = await meditor.Send(new GetCarsByManufacturerIdQuery(manufacturerId));
        return Ok(allCars);
    }
    #endregion

    #region UPDATE

    [HttpPatch]
    [Route("UpdateCarById")]
    public async Task<IActionResult> UpdateCarById(Guid Id, [FromBody] UpdateCarCommand command) { //Change this from body to parameters 
        command.Id = Id;
        var entity = await meditor.Send(command);
        if (entity != null) return Ok(entity);
        return NotFound();
    }
    [HttpPatch]
    [Route("UpdateCarModelById")]
    public async Task<IActionResult> UpdateCarModelById([FromBody] UpdateCarModelCommand command) { //Change this from body to parameters 
        var entity = await meditor.Send(command);
        if (entity != null) return Ok(entity);
        return NotFound();
    }
    #endregion

    #region DELETE
    [HttpDelete]
    [Route("DeleteCarsById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCarsById(Guid id) {
        var isDeleted = await meditor.Send(new DeleteCarCommand(id) {
            Id = id
        });
        if (isDeleted) return Ok();
        return NotFound();

    }
    [HttpDelete]
    [Route("DeleteCarsByManufacturerId")]
    public async Task<IActionResult> DeleteCarsByManufacturerId(Guid id) {
        var isDeleted = await meditor.Send(new DeleteCarsByManufacturerIdCommand(id) {
            Id = id
        });
        if (isDeleted) return Ok();
        return NotFound();
    }

    #endregion


}