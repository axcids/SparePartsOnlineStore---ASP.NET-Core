using Microsoft.AspNetCore.Mvc;
using MediatR;
using Spareparts.Application.Categories.Commands.CreateNewCategory;
using Spareparts.Application.Categories.Queries.GetAllCategories;
using Spareparts.Application.Categories.Commands.UpdateCategoryByIdCommand;
using Spareparts.Application.Categories.Commands.DeleteCategoryByIdCommand;
using Spareparts.Application.Categories.Queries.GetCategoryById;

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
    [HttpGet]
    [Route("GetCategoryById")]
    public async Task<IActionResult> GetCategoryById([FromQuery] Guid id) {
        var category = await meditor.Send(new GetCategoryByIdQuery(id) {
            Id = id
        });
        if (category != null) return Ok(category);
        return NotFound();
    }

    #endregion
    #region Update
    [HttpPatch]
    [Route("UpdateCategoryById")]
    public async Task<IActionResult> UpdateCategoryById([FromQuery] Guid id, [FromBody] UpdateCategoryByIdCommand command) {
        command.Id = id;
        var newEntity = await meditor.Send(command);
        if(newEntity != null) return Ok(newEntity);
        return NotFound();

    }
    #endregion
    #region DELETE
    [HttpDelete]
    [Route("DeleteCategoryById")]
    public async Task<IActionResult> DeleteCategoryById(Guid id) {
        var isDeleted = await meditor.Send(new DeleteCategoryByIdCommand(id) {
            Id = id
        });
        if (isDeleted) return Ok();
        return NotFound();
    }

    #endregion


}
