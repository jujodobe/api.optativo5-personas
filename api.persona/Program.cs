using api.persona.Validaciones;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Agregar FluentValidation al programa
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Add services to the container.
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var result = new BadRequestObjectResult(context.ModelState);
            // Aquí puedes agregar lógica adicional para personalizar la respuesta
            return result;
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("postgresConnection");
builder.Services.AddDbContext<ContextoAplicacionDB>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
