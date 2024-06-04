using api.persona.Filters;
using api.persona.Validaciones;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluentValidationAutoValidation(); //Activar validaciones automaticas
builder.Services.AddScoped<IValidator<ActualizarPersonaRequest>, ActualizarPersonaValidation>(); //Registra la clase validadora
builder.Services.AddScoped<IValidator<CrearPersonaRequest>, CrearPersonaValidacion>(); //Registra la clase validadora
builder.Services.AddValidatorsFromAssemblyContaining<ActualizarPersonaRequest>(); //Registra todas las clases a validar

builder.Services.AddControllers(options =>
{
    options.Filters.Add<FiltroValidacion>();
    options.Filters.Add<FiltroImprimirInfo>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("postgresConnection");
builder.Services.AddDbContext<ContextoAplicacionDB>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
