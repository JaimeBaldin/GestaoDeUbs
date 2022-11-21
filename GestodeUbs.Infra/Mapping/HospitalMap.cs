using GestaoDeUbs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestodeUbs.Infra.Mapping;

public class HospitalMap : IEntityTypeConfiguration<HospitalEntidade>
{
    public void Configure(EntityTypeBuilder<HospitalEntidade> builder)
    {
        builder.ToTable("Hospital");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("varchar")
            .HasMaxLength(100);

        builder.Property(x => x.Endereco)
            .IsRequired()
            .HasColumnName("Endereco")
            .HasColumnType("varchar")
            .HasMaxLength(100);

        builder.Property(x => x.Especialidades)
            .IsRequired()
            .HasColumnName("Especialidades")
            .HasColumnType("varchar")
            .HasMaxLength(100);

    }
}
