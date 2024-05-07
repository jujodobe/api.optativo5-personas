using Microsoft.EntityFrameworkCore;
using Repository.Entidades;

namespace Repository.Contexts;

//Representa mi BD
public class ContextoAplicacionDB : DbContext
{
    //Representa mi tabla Personas
    public DbSet<Persona> Personas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Persona>()
            .HasKey(p => p.Id);

        base.OnModelCreating(modelBuilder);
    }

    public ContextoAplicacionDB(DbContextOptions<ContextoAplicacionDB> options) : base(options)
    {
    }
}
