using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Queries;
using GestaoDeUbs.Domain.Repository;
using System.Security.Cryptography.X509Certificates;

namespace GestaoUbs.Tests.Repositories;

public class MockEncaminhamentoRepository : IEncaminhamentoRepositorio
{
    private IList<EncaminhamentoEntidade> _encaminhamentos;

    public MockEncaminhamentoRepository()
    {
        _encaminhamentos = new List<EncaminhamentoEntidade>();
        _encaminhamentos.Add(CriarEncaminhamento(1,"Teste","Observacao","18111991",1,2));
        _encaminhamentos.Add(CriarEncaminhamento(2,"Teste2","Observacao2","18111991",2,1));
        
    }

    private EncaminhamentoEntidade CriarEncaminhamento(int id, string motivo, string observacao, string data, int idPaciente, int idHospital)
    {
        return new EncaminhamentoEntidade(id, motivo, observacao, data, idPaciente, idHospital)
        {
            Paciente = new MockPacienteRepository().BuscarPorId(idPaciente),
        };
    }




    public IEnumerable<EncaminhamentoEntidade> BuscarPorPaciente(int IdPaciente)
        {
            return _encaminhamentos
                .AsQueryable()
                .Where(EncaminhamentoQueries.BuscarPorPaciente(IdPaciente))
                .ToList();
        }

    public IEnumerable<EncaminhamentoEntidade> BuscarPorHospital(int IdHospital)
    {
        return _encaminhamentos
            .AsQueryable()
            .Where(EncaminhamentoQueries.BuscarPorHospital(IdHospital))
            .ToList();
    }

    public EncaminhamentoEntidade? BuscarPorId(int id)
    {
        return _encaminhamentos
            .AsQueryable()
            .Where(EncaminhamentoQueries.BuscarPorId(id))
            .FirstOrDefault();
    }

    public IEnumerable<EncaminhamentoEntidade> BuscarTodos()
    {
        return _encaminhamentos;
    }

    public void Inserir(EncaminhamentoEntidade encaminhamento) { }

    public void Alterar(EncaminhamentoEntidade encaminhamento) { }

    public void Excluir(EncaminhamentoEntidade encaminhamento) { }


}
