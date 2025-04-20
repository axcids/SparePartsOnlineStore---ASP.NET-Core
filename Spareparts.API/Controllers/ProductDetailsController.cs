using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.CarsProducts.Commands.CreateCarProducts;
using Spareparts.Application.ProductsDetails.Commands.CreateNewProductDetails;
using Spareparts.Application.ProductsDetails.Queries.GetAllProductsDetails;

namespace Spareparts.API.Controllers;
[ApiController]
[Route("api/productdetails/")]
public class ProductDetailsController (IMediator mediator) : Controller {

    #region POST
    [HttpPost]
    [Route("AddNewProduct")]
    public async Task<IActionResult> AddNewProduct([FromBody] CreateNewProductDetailsCommand productDetailsCommand, [FromQuery] Guid carId, [FromQuery] Guid supplierId) {
        var productId = await mediator.Send(productDetailsCommand);
        if (productId != default(Guid)) return Ok(productId);
        return null;
    }

    #endregion

    #region GET
    [HttpGet]
    [Route("GetAllCarProduct")]
    public async Task<IActionResult> GetAllCarProduct() {
        var AllProductDetails = await mediator.Send(new GetAllProductsDetailsQuery());
        return Ok(AllProductDetails);
    }

    #endregion
}
