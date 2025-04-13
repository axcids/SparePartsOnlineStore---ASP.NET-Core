using Microsoft.AspNetCore.Mvc;
using MediatR;
using Spareparts.Application.Categories.Commands.CreateNewCategory;
using Spareparts.Application.Categories.Queries.GetAllCategories;

namespace Spareparts.API.Controllers;
[ApiController]
[Route("api/Category/")]
public class CategoryController (IMediator meditor) : Controller {

    #region POST 
    [HttpPost]
    [Route("AddNewCategory")]
    public async Task<IActionResult> AddNewCategory([FromBody] CreateNewCategoryCommand command) {
        var id = await meditor.Send(command);
        if (id != default(Guid)) return Ok(id);
        return null;
    }

    #endregion
    [HttpGet]
    [Route("GetAllCategories")]
    #region GET
    public async Task<IActionResult> GetAllCategories() {
       var allCategories = await meditor.Send(new GetAllCategoriesQuery());
        return Ok(allCategories);
    }
    #endregion

}
