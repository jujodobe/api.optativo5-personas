using Repository.Contexts;
using Repository.Entidades;
using Repository.Models;
using Repository.Repository.Referenciales;

namespace Service.Logica.Referenciales;

public class PersonaService2
{
    private readonly PersonaRepository2 _repository;

    public PersonaService2(ContextoAplicacionDB contexto)
    {
        _repository = new PersonaRepository2(contexto);
    }

    public int Agregar(string nombre, string apellido, int anhoNacimiento)
    {
        return _repository.Agregar(nombre, apellido, anhoNacimiento);
    }

    public PersonaConCuentas ObtenerPorId(int id)
    {
        return _repository.ObtenerPorId(id);
    }

    public Persona Actualizar(int id, string nombre)
    {
        return _repository.Actualizar(id, nombre);
    }

    public string Eliminar(int id)
    {
        return _repository.Eliminar(id);
    }
}
