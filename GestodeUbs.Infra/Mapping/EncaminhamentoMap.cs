using GestaoDeUbs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestodeUbs.Infra.Mapping;

public class EncaminhamentoMap : IEntityTypeConfiguration<EncaminhamentoEntidade>
{
    public void Configure(EntityTypeBuilder<EncaminhamentoEntidade> builder)
    {
        builder.ToTable("Encaminhamento");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.DataEncaminhamento)
            .IsRequired()
            .HasColumnName("DataEncaminhamento")
            .HasColumnType("varchar");

        builder.Property(x => x.Observacoes)
            .IsRequired()
            .HasColumnName("Observacoes")
            .HasColumnType("varchar")
            .HasMaxLength(100);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("varchar")
            .HasMaxLength(100);

        builder.HasOne(x => x.Paciente)
            .WithMany(x => x.Encaminhamentos)
            .HasConstraintName("FK_Encaminhamento_Paciente");

        builder.HasOne(x => x.Hospital)
            .WithMany(x => x.Encaminhamentos)
            .HasConstraintName("FK_Encaminhamento_Hospital");

    }
}
