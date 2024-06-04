using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace api.persona.Filters;

public class FiltroValidacion : IActionFilter
{
    //Se ejecuta antes de procesar la solicitud
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("He pasado por aqui 1");

        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }

    //Luego de haber procesado la solicitud
    public void OnActionExecuted(ActionExecutedContext context) {
        Console.WriteLine("He pasado por aqui 2");
    }
}
