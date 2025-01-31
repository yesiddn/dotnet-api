using dotnet_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  IHelloWorldService _helloWorldService;

  public HelloWorldController(IHelloWorldService helloWorldService)
  {
    _helloWorldService = helloWorldService;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(_helloWorldService.GetHelloWorld());
  }
}