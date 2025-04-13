using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Suppliers.Commands;

namespace Spareparts.API.Controllers;
[ApiController]
[Route("api/supplier/")]
public class SupplierController (IMediator meditor) : Controller {
    [HttpPost]
    [Route("AddNewSupplier")]
    public async Task<IActionResult> AddNewSupplier([FromBody] CreateNewSupplierCommand command) {
        var id = await meditor.Send(command);
        if (id != default(Guid)) return Ok(id);
        return null;
    }
}
