using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spareparts.Application.ProductsDetails.Commands.CreateNewProductDetails;
using Spareparts.Application.ProductsDetails.Queries.GetAllProductsDetails;

namespace Spareparts.API.Controllers;
[ApiController]
[Route("api/productdetails/")]
public class ProductDetailsController (IMediator mediator) : Controller {

    #region POST
    [HttpPost]
    [Route("AddNewProduct")]
    public async Task<IActionResult> AddNewCarProduct([FromBody] CreateNewProductDetailsCommand command) {
        var id = await mediator.Send(command);
        if(id != default(Guid)) return Ok(id);
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
