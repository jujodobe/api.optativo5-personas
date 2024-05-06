using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.Logica.Referenciales;

namespace api.persona.Controllers
{
    [Route("api/v1/[controller]")]
    public class PersonaController : Controller
    {
        private PersonaService personaService;
        public PersonaController(IConfiguration configuracion)
        {
            personaService = new PersonaService(configuracion.GetConnectionString("postgresConnection"));
        }
        [HttpPost]
        public ActionResult add([FromBody] PersonaModel persona)
        {
            personaService.add(persona);
            return Ok(new { message = "Registro insertado Correctamente"});
        }
    }
}
