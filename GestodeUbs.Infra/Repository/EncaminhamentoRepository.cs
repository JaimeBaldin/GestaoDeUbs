using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Queries;
using GestaoDeUbs.Domain.Repository;
using GestodeUbs.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestodeUbs.Infra.Repository;

public class EncaminhamentoRepository : IEncaminhamentoRepositorio
{
    private readonly DataContext _contexto;

    public EncaminhamentoRepository(DataContext contexto)
    {
        _contexto = contexto;
    }

    public void Inserir(EncaminhamentoEntidade encaminhamento)
    {
        _contexto.Encaminhamentos.Add(encaminhamento);
        _contexto.SaveChanges();
    }

    public void Alterar(EncaminhamentoEntidade encaminhamento)
    {
        _contexto.Entry(encaminhamento).State = EntityState.Modified;
        _contexto.SaveChanges();
    }

    public void Excluir(EncaminhamentoEntidade encaminhamento)
    {
        _contexto.Remove(encaminhamento);
        _contexto.SaveChanges();
    }

    public EncaminhamentoEntidade? BuscarPorId(int id)
    {
        return _contexto.Encaminhamentos
            .Where(EncaminhamentoQueries.BuscarPorId(id))
            .FirstOrDefault();
    }

    public IEnumerable<EncaminhamentoEntidade> BuscarPorPaciente(int idPaciente)
    {
        return _contexto.Encaminhamentos
            .AsNoTracking()
            .Include(x => x.Paciente)
            .Where(EncaminhamentoQueries.BuscarPorPaciente(idPaciente))
            .OrderBy(x => x.Nome);
    }

    public IEnumerable<EncaminhamentoEntidade> BuscarPorHospital(int idHospital)
    {
        return _contexto.Encaminhamentos
            .AsNoTracking()
            .Include(x => x.Hospital)
            .Where(EncaminhamentoQueries.BuscarPorHospital(idHospital))
            .OrderBy(x => x.Nome);
    }


    public IEnumerable<EncaminhamentoEntidade> BuscarTodos()
    {
        return _contexto.Encaminhamentos
            .AsNoTracking()
            .Include(x => x.Paciente)
            .Include(x => x.Hospital);
    }
}
