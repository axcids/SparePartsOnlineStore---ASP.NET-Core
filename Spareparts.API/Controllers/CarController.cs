using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Cars.Commands.CreateCar;
using Spareparts.Application.Cars.Commands.DeleteCar;
using Spareparts.Application.Cars.Queries.GetAllCars;
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
    [Route("GetCarsByManufacturerId")]
    public async Task<IActionResult> GetCarsByManufacturerId() {
        throw new NotImplementedException();
    }
    #endregion
    
    #region UPDATE
    [HttpPatch]
    [Route("UpdateCarsById")]
    public async Task<IActionResult> UpdateCarsById() {
        throw new NotImplementedException();
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
            Id= id
        });
        if(isDeleted) return Ok();
        return NotFound();
    }

    #endregion
}