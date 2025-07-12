using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.Products.Commands.CreateNewProduct;
using Spareparts.Application.Products.Commands.DeleteProductById;
using Spareparts.Application.Products.Queries.GetAllProducts;


namespace Spareparts.API.Controllers;
[ApiController]
[Route("api/Product/")]
public class ProductController (IMediator mediator) : Controller {

    #region POST
    [HttpPost]
    [Route("AddNewProduct")]
    public async Task<IActionResult> AddNewProduct([FromBody] CreateNewProductCommand ProductCommand) {
        var productId = await mediator.Send(ProductCommand);
        if (productId != default(Guid)) return Ok(productId);
        return null;
    }

    #endregion

    #region GET
    [HttpGet]
    [Route("GetAllProduct")]
    public async Task<IActionResult> GetAllProduct() {
        var AllProduct = await mediator.Send(new GetAllProductsQuery());
        return Ok(AllProduct);
    }

    #endregion
    #region DELETE
    [HttpDelete]
    [Route("DeleteProductById")]
    public async Task<IActionResult> DeleteProductById(Guid id) {
        var isDeleted = await mediator.Send(new DeleteProductByIdCommand(id));
        if (isDeleted) return Ok();
        return NotFound();
    }
    #endregion
}
