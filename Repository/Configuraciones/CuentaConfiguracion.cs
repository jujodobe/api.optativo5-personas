using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entidades;

namespace Repository.Configuraciones;

public class CuentaConfiguracion : IEntityTypeConfiguration<Cuenta>
{
    public void Configure(EntityTypeBuilder<Cuenta> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(cuenta => cuenta.Titular)
            .WithMany(persona => persona.Cuentas)
            .HasForeignKey(cuenta => cuenta.PersonaId);
    }
}
