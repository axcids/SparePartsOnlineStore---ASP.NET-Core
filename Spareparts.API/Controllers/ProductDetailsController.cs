using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.ProductsDetails.Commands.CreateNewProductDetails;
using Spareparts.Application.ProductsDetails.Commands.DeleteProductDetailsById;
using Spareparts.Application.ProductsDetails.Queries.GetAllProductsDetails;

namespace Spareparts.API.Controllers;
[ApiController]
[Route("api/productdetails/")]
public class ProductDetailsController (IMediator mediator) : Controller {

    #region POST
    [HttpPost]
    [Route("AddNewProduct")]
    public async Task<IActionResult> AddNewProduct([FromBody] CreateNewProductDetailsCommand productDetailsCommand) {
        var productId = await mediator.Send(productDetailsCommand);
        if (productId != default(Guid)) return Ok(productId);
        return null;
    }

    #endregion

    #region GET
    [HttpGet]
    [Route("GetAllProductsDetails")]
    public async Task<IActionResult> GetAllProductsDetails() {
        var AllProductDetails = await mediator.Send(new GetAllProductsDetailsQuery());
        return Ok(AllProductDetails);
    }

    #endregion
    #region DELETE
    [HttpDelete]
    [Route("DeleteProductDetailsById")]
    public async Task<IActionResult> DeleteProductDetailsById(Guid id) {
        var isDeleted = await mediator.Send(new DeleteProductDetailsByIdCommand(id));
        if (isDeleted) return Ok();
        return NotFound();
    }
    #endregion
}
