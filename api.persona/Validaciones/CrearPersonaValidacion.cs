using FluentValidation;
using Repository.Models;

namespace api.persona.Validaciones;

public class CrearPersonaValidacion : AbstractValidator<CrearPersonaRequest>
{
    public CrearPersonaValidacion()
    {
        RuleFor(persona => persona.AnhoNacimiento)
            .GreaterThan(1849)
            .WithMessage("El año de nacimiento minimo es 1850");

        //Regla condicional
        //Si el año de nacimiento de la persona es mayor a 2000,
        //entonces la cantidad minima de caracteres del nombre debe ser 10

        RuleFor(persona => persona.Nombre)
            .MinimumLength(10)
            .When(persona => persona.AnhoNacimiento > 2000)
            .WithMessage("Cuando el año es mayor a 2000, el nombre debe tener como minimo 10 caracteres");
    }
}
