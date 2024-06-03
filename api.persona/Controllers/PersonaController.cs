using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Repository.Contexts;
using Repository.Entidades;
using Repository.Models;
using Service.Logica.Referenciales;
using System;

namespace api.persona.Controllers
{
    [Route("api/v1/[controller]")]
    public class PersonaController : Controller
    {
        private PersonaService personaService;
        private PersonaService2 personaService2;
        IValidator<ActualizarPersonaRequest> _validator;

        public PersonaController(IConfiguration configuracion, ContextoAplicacionDB contexto, IValidator<ActualizarPersonaRequest> validator)
        {
            personaService = new PersonaService(configuracion.GetConnectionString("postgresConnection"));
            personaService2 = new PersonaService2(contexto);
            _validator = validator;
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
            if(persona.AnhoNacimiento < 1900)
            {
                throw new Exception("El año de nacimiento debe ser mayor a 1900");
            }

            int resultado = personaService2.Agregar(persona.Nombre, persona.Apellido, persona.AnhoNacimiento);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public ActionResult ObtenerPorId([FromRoute] int id)
        {
            var resultado = personaService2.ObtenerPorId(id);
            return Ok(resultado);
        }

        //[HttpPut("{id}")]
        //public ActionResult Actualizar([FromRoute] int id, [FromBody] string nombre)
        //{
        //    var resultado = personaService2.Actualizar(id, nombre);
        //    return Ok(resultado);
        //}

        [HttpPut]
        public IActionResult Actualizar([FromBody] ActualizarPersonaRequest request)
        {
            var resultado = personaService2.Actualizar(request);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar([FromRoute] int id)
        {
            var resultado = personaService2.Eliminar(id);
            return Ok(resultado);
        }
    }
}
