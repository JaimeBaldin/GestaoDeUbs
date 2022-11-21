using GestaoDeUbs.Domain.Entities;
using GestodeUbs.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GestodeUbs.Infra.Context;

public class DataContext : DbContext
{
    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<PacienteEntidade> Pacientes { get; set; }
    public DbSet<HospitalEntidade> Hospitais { get; set; }
    public DbSet<EncaminhamentoEntidade> Encaminhamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PacienteMap());
        modelBuilder.ApplyConfiguration(new HospitalMap());
        modelBuilder.ApplyConfiguration(new EncaminhamentoMap());
    }
}
