namespace dotnet_api.Services;

public class HelloWorldService : IHelloWorldService
{
  public string GetHelloWorld()
  {
    return "Hello World!";
  }
}

public interface IHelloWorldService
{
  string GetHelloWorld();
}
