using Microsoft.AspNetCore.Mvc;
using Repository.Contexts;
using Repository.Entidades;
using Repository.Models;
using Service.Logica.Referenciales;

namespace api.persona.Controllers
{
    [Route("api/v1/[controller]")]
    public class PersonaController : Controller
    {
        private PersonaService personaService;
        private PersonaService2 personaService2;

        public PersonaController(IConfiguration configuracion, ContextoAplicacionDB contexto)
        {
            personaService = new PersonaService(configuracion.GetConnectionString("postgresConnection"));
            personaService2 = new PersonaService2(contexto);
        }
        [HttpPost]
        public ActionResult add([FromBody] PersonaModel persona)
        {
            personaService.add(persona);
            return Ok(new { message = "Registro insertado Correctamente"});
        }

        [HttpPost("entity-framework")]
        public ActionResult AgregarConEntity([FromBody] Persona persona)
        {
            int resultado = personaService2.Agregar(persona.Nombre, persona.Apellido, persona.AnhoNacimiento);
            return Ok(resultado);
        }
    }
}
