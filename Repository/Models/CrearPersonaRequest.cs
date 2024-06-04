namespace Repository.Models;

public class CrearPersonaRequest
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public int AnhoNacimiento { get; set; }
    public string Apellido { get; set; } = "";
}
