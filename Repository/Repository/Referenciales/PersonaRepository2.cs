using Repository.Contexts;
using Repository.Entidades;

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
}
