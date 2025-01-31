namespace dotnet_api.Middlewares;

public class TimeMiddleware 
{
  readonly RequestDelegate _next;

  public TimeMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task Invoke(HttpContext context)
  {
    // await _next(context); // Call the next delegate/middleware in the pipeline

    // de esta forma, el middleware ejecuta su logica al final de la petición, cuando se esta regresando la respuesta
    if (context.Request.Query.Any(q => q.Key == "time")) // Check if the query string contains the key "time"
    {
      await context.Response.WriteAsync(DateTime.Now.ToShortTimeString()); // Write the current date to the response
      return; // hay que poner return en este caso porque con WriteAsync estoy escribiendo en la respuesta por lo que los headers se vuelven de solo lectura y en caso de que el controlador quiera modificarlos, no podrá hacerlo
      // ver InvalidOperationException error
    }

    await _next(context); // cuando se pone en este punto, el middleware ejecuta su logica al inicio de la petición y esto hace que no se pueda acceder a la respuesta del controlador
  }
}

// clase de extensión para el middleware, es decir, una clase que contiene un método de extensión que agrega el middleware a la canalización de solicitud
public static class TimeMiddlewareExtension
{
  public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder) // se obtiene el IApplicationBuilder y se agrega el middleware al pipeline y se devuelve el IApplicationBuilder para que se pueda encadenar con otros métodos de configuración de middleware
  {
    return builder.UseMiddleware<TimeMiddleware>();
  }
}
