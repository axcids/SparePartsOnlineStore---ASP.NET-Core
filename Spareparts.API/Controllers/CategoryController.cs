using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Spareparts.API.Controllers;
[ApiController]
[Route("api/Category/")]
public class CategoryController (IMediator meditor) : Controller {

    #region POST 
    [HttpPost]
    [Route("AddNewCategory")]
    public async Task<IActionResult> AddNewCategory([FromBody] CreateCategoryCommand command) {
        var id = await meditor.Send(command);
        if (id != default(Guid)) return Ok(id);
        return null;
    }

    #endregion

}
