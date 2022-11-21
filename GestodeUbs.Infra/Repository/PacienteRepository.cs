using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Queries;
using GestaoDeUbs.Domain.Repository;
using GestodeUbs.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestodeUbs.Infra.Repository;

public class PacienteRepository : IPacienteRepositorio
{
    private readonly DataContext _contexto;

    public PacienteRepository(DataContext contexto)
    {
        _contexto = contexto;
    }

    public void Inserir(PacienteEntidade paciente)
    {
        _contexto.Pacientes.Add(paciente);
        _contexto.SaveChanges();
    }

    public void Alterar(PacienteEntidade paciente)
    {
        _contexto.Entry(paciente).State = EntityState.Modified;
        _contexto.SaveChanges();
    }

    public void Excluir(PacienteEntidade paciente)
    {
        _contexto.Remove(paciente);
        _contexto.SaveChanges();
    }

    public PacienteEntidade? BuscarPorId(int id)
    {
        return _contexto.Pacientes
            .Where(PacienteQueries.BuscarPorId(id))
            .FirstOrDefault();
    }

    public IEnumerable<PacienteEntidade> BuscarTodos()
    {
        return _contexto.Pacientes
            .AsNoTracking()
            .Include(x => x.Encaminhamentos)
            .Include(x => x.Nome);
    }
}
