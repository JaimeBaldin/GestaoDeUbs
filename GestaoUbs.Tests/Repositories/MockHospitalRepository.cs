using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Queries;
using GestaoDeUbs.Domain.Repository;

namespace GestaoUbs.Tests.Repositories;

public class MockHospitalRepository : IHospitalRepositorio
{
    private IList<HospitalEntidade> _hospitais;

    public MockHospitalRepository()
    {
        _hospitais = new List<HospitalEntidade>();
        _hospitais.Add(new HospitalEntidade(1, "Hospital 1", "Rua 1", "12345678"));
        _hospitais.Add(new HospitalEntidade(2, "Hospital 2", "Rua 2", "12345678"));
    }

    public HospitalEntidade? BuscarPorId(int id)
    {
        return _hospitais
            .AsQueryable()
            .Where(HospitalQueries.BuscarPorId(id))
            .FirstOrDefault();
    }

    public IEnumerable<HospitalEntidade> BuscarTodos()
    {
        return _hospitais;
    }

    public void Inserir(HospitalEntidade hospital) { }

    public void Alterar(HospitalEntidade hospital) { }

    public void Excluir(HospitalEntidade hospital) { }
}
