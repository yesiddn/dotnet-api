using dotnet_api.Models;
using dotnet_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
  protected readonly ITaskService _taskService;

  public TaskController(ITaskService taskService)
  {
    _taskService = taskService;
  }

  [HttpGet]
  public IActionResult GetTasks()
  {
    var tasks = _taskService.GetTasks();
    return Ok(tasks);
  }

  [HttpPost]
  public IActionResult AddTask([FromBody] Models.Task task)
  {
    _taskService.CreateTask(task);
    return Created("Task", task);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateTask(Guid id, [FromBody] Models.Task task)
  {
    _taskService.UpdateTask(id, task);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteTask(Guid id)
  {
    _taskService.DeleteTask(id);
    return Ok();
  }
}