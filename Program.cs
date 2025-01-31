using dotnet_api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // middleware para habilitar CORS

app.UseAuthorization();

app.UseWelcomePage(); // middleware para mostrar una pagina de bienvenida
// en este punto se ponen los middlewares personalizados

app.UseTimeMiddleware(); // middleware personalizado

app.MapControllers();

app.Run();
