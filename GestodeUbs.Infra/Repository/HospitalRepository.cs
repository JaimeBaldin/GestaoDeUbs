using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Queries;
using GestaoDeUbs.Domain.Repository;
using GestodeUbs.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestodeUbs.Infra.Repository;

public class HospitalRepository : IHospitalRepositorio
{
    private readonly DataContext _contexto;

    public HospitalRepository(DataContext contexto)
    {
        _contexto = contexto;
    }

    public void Inserir(HospitalEntidade hospital)
    {
        _contexto.Hospitais.Add(hospital);
        _contexto.SaveChanges();
    }

    public void Alterar(HospitalEntidade hospital)
    {
        _contexto.Entry(hospital).State = EntityState.Modified;
        _contexto.SaveChanges();
    }

    public void Excluir(HospitalEntidade hospital)
    {
        _contexto.Remove(hospital);
        _contexto.SaveChanges();
    }

    public HospitalEntidade? BuscarPorId(int id)
    {
        return _contexto.Hospitais
            .Where(HospitalQueries.BuscarPorId(id))
            .FirstOrDefault();
    }

    public IEnumerable<HospitalEntidade> BuscarTodos()
    {
        return _contexto.Hospitais
            .AsNoTracking()
            .Include(x => x.Encaminhamentos);
    }
}
