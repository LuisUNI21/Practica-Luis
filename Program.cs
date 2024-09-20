using PRACTICA.Services.Implementation;
using PRACTICA.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IEstudianteService, EstudianteService>();
var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
