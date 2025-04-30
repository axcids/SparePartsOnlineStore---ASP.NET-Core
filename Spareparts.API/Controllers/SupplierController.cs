using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Suppliers.Commands.CreateNewSupplier;
using Spareparts.Application.Suppliers.Commands.DeleteSupplierById;
using Spareparts.Application.Suppliers.Commands.UpdateSupplierById;
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
    #region UPDATE
    [HttpPatch]
    [Route("UpdateSupplierById")]
    public async Task<IActionResult> UpdateSupplierById([FromQuery] Guid id, [FromBody] UpdateSupplierByIdCommand command) {
        command.Id = id;
        var entity = await meditor.Send(command);
        if (entity != null) return Ok();
        return NotFound();
    }
    #endregion
    #region DELETE
    [HttpDelete]
    [Route("DeleteSupplierById")]
    public async Task<IActionResult> DeleteSupplierById([FromQuery] Guid id) {
        var isDeleted = await meditor.Send(new DeleteSupplierByIdCommand(id) {
            Id = id
        });
        if (isDeleted) return Ok();
        return NotFound();
    }
    #endregion
}
