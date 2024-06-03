using FluentValidation;
using Repository.Models;

namespace api.persona.Validaciones;

public class ActualizarPersonaValidation : AbstractValidator<ActualizarPersonaRequest>
{
    public ActualizarPersonaValidation()
    {
        RuleFor(persona => persona.AnhoNacimiento)
            .GreaterThan(1900)
            .WithMessage("El año de nacimiento debe de ser mayor a 1900.");

        RuleFor(persona => persona.Nombre)
            .MinimumLength(5)
            .WithMessage("La cantidad minima de caracteres es 5");

        RuleFor(persona => persona.Nombre)
            .MaximumLength(15)
            .WithMessage("La cantidad maxima de caracteres es 15");
    }
}
