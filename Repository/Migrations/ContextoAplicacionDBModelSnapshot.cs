﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository.Contexts;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ContextoAplicacionDB))]
    partial class ContextoAplicacionDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Repository.Entidades.Cuenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonaId")
                        .HasColumnType("integer");

                    b.Property<int>("SaldoActual")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("Repository.Entidades.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnhoNacimiento")
                        .HasColumnType("integer");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Repository.Entidades.Cuenta", b =>
                {
                    b.HasOne("Repository.Entidades.Persona", "Titular")
                        .WithMany("Cuentas")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Titular");
                });

            modelBuilder.Entity("Repository.Entidades.Persona", b =>
                {
                    b.Navigation("Cuentas");
                });
#pragma warning restore 612, 618
        }
    }
}
