namespace Repository.Entidades;

public class Cuenta
{
    /*
     * Id - int
        Numero - string
        SaldoActual - int
        PersonaId (Fk) - int
    */

    public int Id { get; set; }
    public string Numero { get; set; } = "";
    public int SaldoActual { get; set; }

    //Relaciones
    public int PersonaId { get; set; }
    public Persona Titular { get; set; }
}
