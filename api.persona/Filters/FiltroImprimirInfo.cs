using Microsoft.AspNetCore.Mvc.Filters;

namespace api.persona.Filters;

public class FiltroImprimirInfo : IActionFilter
{

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("otro filtro se ha ejecutado 3");
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("otro filtro se ha ejecutado 4");
    }
}
