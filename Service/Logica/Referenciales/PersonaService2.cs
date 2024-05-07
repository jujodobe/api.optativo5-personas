using Repository.Contexts;
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
}
