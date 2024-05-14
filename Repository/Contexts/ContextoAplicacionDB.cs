using Microsoft.EntityFrameworkCore;
using Repository.Configuraciones;
using Repository.Entidades;

namespace Repository.Contexts;

//Representa mi BD
public class ContextoAplicacionDB : DbContext
{
    //Representa mi tabla Personas
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Cuenta> Cuentas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonaConfiguracion());
        modelBuilder.ApplyConfiguration(new CuentaConfiguracion());

        base.OnModelCreating(modelBuilder);
    }

    public ContextoAplicacionDB(DbContextOptions<ContextoAplicacionDB> options) : base(options)
    {
    }
}
