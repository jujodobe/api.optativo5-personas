using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entidades;

namespace Repository.Configuraciones;

public class PersonaConfiguracion : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .HasMany(p => p.Cuentas)
            .WithOne(c => c.Titular)
            .HasForeignKey(c => c.PersonaId);
    }
}
