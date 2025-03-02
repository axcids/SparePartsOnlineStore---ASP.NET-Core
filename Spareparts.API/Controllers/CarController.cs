using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Cars.Commands.CreateCar;
using Spareparts.Application.Cars.Queries.GetAllCars;

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

    #region GET
    [HttpGet]
    [Route("GetAllCars")]
    public async Task<IActionResult> GetAllCars() {
        var allCars = await medator.Send(new GetAllCarsQuery());
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
    public async Task<IActionResult> DeleteCarsById() {
        throw new NotImplementedException();
    }
    [HttpDelete]
    [Route("DeleteCarsByManufacturerId")]
    public async Task<IActionResult> DeleteCarsByManufacturerId() {
        throw new NotImplementedException();
    }
    #endregion
}