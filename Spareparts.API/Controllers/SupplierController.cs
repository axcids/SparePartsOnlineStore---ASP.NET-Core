using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Suppliers.Commands.CreateNewSupplier;
using Spareparts.Application.Suppliers.Queries.GetAllSuppliers;
using Spareparts.Application.Suppliers.Queries.GetSupplierById;

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
    [HttpGet]
    [Route("GetSupplierById")]
    public async Task<IActionResult> GetSupplierById(Guid id) {
        var supplier = await meditor.Send(new GetSupplierByIdQuery(id));
        return Ok(supplier);
    }
    #endregion
}
