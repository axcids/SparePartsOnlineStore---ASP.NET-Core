using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Suppliers.Commands;
using Spareparts.Application.Suppliers.Queries.GetAllSuppliers;

namespace Spareparts.API.Controllers;
[ApiController]
[Route("api/supplier/")]
public class SupplierController (IMediator meditor) : Controller {
    #region POST
    [HttpPost]
    [Route("AddNewSupplier")]
    public async Task<IActionResult> AddNewSupplier([FromBody] CreateNewSupplierCommand command) {
        var id = await meditor.Send(command);
        if (id != default(Guid)) return Ok(id);
        return null;
    }
    #endregion
    #region GET
    [HttpGet]
    [Route("GetAllSuppliers")]
    public async Task<IActionResult> GetAllSuppliers() {
        var allSuppliers = await meditor.Send(new GetAllSuppliersQuery());
        return Ok(allSuppliers);
    }
    #endregion
}
