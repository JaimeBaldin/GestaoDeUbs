using GestaoDeUbs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestodeUbs.Infra.Mapping;

public class PacienteMap : IEntityTypeConfiguration<PacienteEntidade>
{
    public void Configure(EntityTypeBuilder<PacienteEntidade> builder)
    {
        builder.ToTable("Paciente");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("varchar")
            .HasMaxLength(100);

        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasColumnName("Cpf")
            .HasColumnType("varchar")
            .HasMaxLength(11);

        builder.Property(x => x.Rg)
            .IsRequired()
            .HasColumnName("Rg")
            .HasColumnType("varchar")
            .HasMaxLength(9);

        builder.Property(x => x.DataDeNascimento)
            .IsRequired()
            .HasColumnName("DataNascimento")
            .HasColumnType("varchar")
            .HasMaxLength(20);

        builder.Property(x => x.Endereco)
            .IsRequired()
            .HasColumnName("Endereco")
            .HasColumnType("varchar")
            .HasMaxLength(100);

    }
}
