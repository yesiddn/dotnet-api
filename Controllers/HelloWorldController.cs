using dotnet_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  IHelloWorldService _helloWorldService;
  ILogger<HelloWorldController> _logger; // en el appsettings.json se puede configurar el nivel de loggeo, para mas info https://learn.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line o notas

  public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger)
  {
    _helloWorldService = helloWorldService;
    _logger = logger;
  }

  [HttpGet]
  public IActionResult Get()
  {
    _logger.LogDebug("Getting hello world");
    return Ok(_helloWorldService.GetHelloWorld());
  }
}