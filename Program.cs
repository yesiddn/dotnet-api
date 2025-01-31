using dotnet_api.Middlewares;
using dotnet_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// se recomienda esta forma de inyectar servicios ya que la idea es que las api sean stateless y con cada petición se cree una nueva instancia del servicio
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); // se crea una nueva instancia de HelloWorldService por cada petición
// builder.Services.AddTransient<IHelloWorldService, HelloWorldService>(); // se crea una nueva instancia de HelloWorldService cada vez que se inyecta en un controlador
// builder.Services.AddSingleton<IHelloWorldService, HelloWorldService>(); // se crea una sola instancia de HelloWorldService y se reutiliza cada vez que se inyecta en un controlador
// builder.Services.AddScoped(s => new HelloWorldService()); // esta es otra forma de inyectar servicios, se crea una nueva instancia de HelloWorldService por cada petición, pero no se recomienda esta forma ya que no es tan flexible como usar interfaces


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // middleware para habilitar CORS

app.UseAuthorization();

// app.UseWelcomePage(); // middleware para mostrar una pagina de bienvenida
// en este punto se ponen los middlewares personalizados

// app.UseTimeMiddleware(); // middleware personalizado

app.MapControllers();

app.Run();
