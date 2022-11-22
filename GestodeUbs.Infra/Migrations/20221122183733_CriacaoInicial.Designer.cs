﻿// <auto-generated />
using GestodeUbs.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestodeUbs.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221122183733_CriacaoInicial")]
    partial class CriacaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GestaoDeUbs.Domain.Entities.EncaminhamentoEntidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DataEncaminhamento")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("DataEncaminhamento");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Observacoes");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Encaminhamento", (string)null);
                });

            modelBuilder.Entity("GestaoDeUbs.Domain.Entities.HospitalEntidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Endereco");

                    b.Property<string>("Especialidades")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Especialidades");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Hospital", (string)null);
                });

            modelBuilder.Entity("GestaoDeUbs.Domain.Entities.PacienteEntidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<string>("DataDeNascimento")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("Rg");

                    b.HasKey("Id");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("GestaoDeUbs.Domain.Entities.EncaminhamentoEntidade", b =>
                {
                    b.HasOne("GestaoDeUbs.Domain.Entities.HospitalEntidade", "Hospital")
                        .WithMany("Encaminhamentos")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Encaminhamento_Hospital");

                    b.HasOne("GestaoDeUbs.Domain.Entities.PacienteEntidade", "Paciente")
                        .WithMany("Encaminhamentos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Encaminhamento_Paciente");

                    b.Navigation("Hospital");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("GestaoDeUbs.Domain.Entities.HospitalEntidade", b =>
                {
                    b.Navigation("Encaminhamentos");
                });

            modelBuilder.Entity("GestaoDeUbs.Domain.Entities.PacienteEntidade", b =>
                {
                    b.Navigation("Encaminhamentos");
                });
#pragma warning restore 612, 618
        }
    }
}