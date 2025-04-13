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
    public async Task<IActionResult> AddNewProduct([FromBody] CreateNewProductDetailsCommand productDetailsCommand) {
        var productId = await mediator.Send(productDetailsCommand);
        // car id : dd1203bc-1810-4a88-0088-08dd7a8f1120
        var carId = Guid.Parse("dd1203bc-1810-4a88-0088-08dd7a8f1120");
        // supplier id : cfaecd71-bf7c-4a70-b996-08dd7a8f36ec
        var supplierId = "0290b227-6c2c-41cb-93d6-5b130d3d416b";
        var carProductId = await mediator.Send(new CreateCarProductCommand(carId, productId));


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
