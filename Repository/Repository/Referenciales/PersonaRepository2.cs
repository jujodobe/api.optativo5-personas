using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Entidades;
using Repository.Models;

namespace Repository.Repository.Referenciales;

public class PersonaRepository2
{
    private readonly ContextoAplicacionDB _contexto;

    public PersonaRepository2(ContextoAplicacionDB contexto)
    {
        _contexto = contexto;
    }

    public int Agregar(string nombre, string apellido, int anhoNacimiento)
    {
        Persona persona = new Persona()
        {
            Nombre = nombre,
            Apellido = apellido,
            AnhoNacimiento = anhoNacimiento
        };

        _contexto.Personas.Add(persona);

        int resultado = _contexto.SaveChanges(); //recien aqui impacto en la BD.

        return resultado;
    }

    public PersonaConCuentas ObtenerPorId(int id)
    {
        //var persona = _contexto.Personas.Find(id);

        var persona = _contexto.Personas
            .Include(persona => persona.Cuentas)
            .FirstOrDefault(persona => persona.Id == id);

        if (persona == null)
        {
            throw new Exception("No se encontro a la persona con el id solicitado");
        }

        //Transformar de entidad a modelo
        var personaConCuentas = new PersonaConCuentas()
        {
            Id = persona.Id,
            Nombre = persona.Nombre,
            Apellido = persona.Apellido,
            AnhoNacimiento = persona.AnhoNacimiento,
            Cuentas = persona.Cuentas.Select(cuenta => new CuentaModelo
            {
                Id = cuenta.Id,
                SaldoActual = cuenta.SaldoActual,
                NumeroCuenta = cuenta.Numero
            }).ToList()
        };

        return personaConCuentas;
    }

    //public Persona Actualizar(int id, string nombre)
    //{
    //    var persona = _contexto.Personas.Find(id);

    //    if (persona == null)
    //    {
    //        throw new Exception("No se encontro a la persona con el id solicitado");
    //    }

    //    persona.Nombre = nombre;

    //    _contexto.SaveChanges();

    //    return persona;
    //}

    public Persona Actualizar(ActualizarPersonaRequest request)
    {
        var persona = _contexto.Personas.Find(request.Id);

        if (persona == null)
        {
            throw new Exception("No se encontro a la persona con el id solicitado");
        }

        persona.Nombre = request.Nombre;

        _contexto.SaveChanges();

        return persona;
    }

    public string Eliminar(int id)
    {
        var persona = _contexto.Personas.Find(id);

        if (persona == null)
        {
            throw new Exception("No se encontro a la persona con el id solicitado");
        }

        _contexto.Personas.Remove(persona);

        _contexto.SaveChanges();

        return "Eliminado exitosamente";
    }
}
