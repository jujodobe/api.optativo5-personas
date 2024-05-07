namespace Repository.Entidades;

public class Persona
{
    /*
     *  -- Id int - pk - autoincremental
        -- Nombre - text
        -- AnhoNacimiento - int
     */

    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public int AnhoNacimiento { get; set; }
    public string Apellido { get; set; } = "";
}
