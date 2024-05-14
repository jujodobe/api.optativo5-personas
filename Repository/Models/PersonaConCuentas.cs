namespace Repository.Models;

public class PersonaConCuentas
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public int AnhoNacimiento { get; set; }
    public string Apellido { get; set; } = "";

    //Relaciones
    public List<CuentaModelo> Cuentas { get; set; } = new List<CuentaModelo>();
}
