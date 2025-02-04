using dotnet_api.Models;
using dotnet_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
  protected readonly ICategoryService _categoryService;

  public CategoryController(ICategoryService categoryService)
  {
    _categoryService = categoryService;
  }

  [HttpGet]
  public IActionResult GetCategories()
  {
    var categories = _categoryService.GetCategories();
    return Ok(categories);
  }

  [HttpPost]
  public IActionResult AddCategory([FromBody] Category category)
  {
    _categoryService.SaveCategory(category);
    return Created("Category", category);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateCategory(Guid id, [FromBody] Category category)
  {
    _categoryService.UpdateCategory(id, category);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteCategory(Guid id)
  {
    _categoryService.DeleteCategory(id);
    return Ok();
  }
}