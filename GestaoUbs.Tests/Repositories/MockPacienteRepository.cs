using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Queries;
using GestaoDeUbs.Domain.Repository;

namespace GestaoUbs.Tests.Repositories;

public class MockPacienteRepository : IPacienteRepositorio
{
    private IList<PacienteEntidade> _pacientes;

    public MockPacienteRepository()
    {
        _pacientes = new List<PacienteEntidade>();
        _pacientes.Add(new PacienteEntidade(1,"Jaime","107279571","07454962963","Rua Manaus","18111991"));
        _pacientes.Add(new PacienteEntidade(2,"Eduardo","107899571","07455632963","Rua Manaus","18111991"));
    }

    public PacienteEntidade? BuscarPorId(int id)
    {
        return _pacientes
            .AsQueryable()
            .Where(PacienteQueries.BuscarPorId(id))
            .FirstOrDefault();
    }

    public IEnumerable<PacienteEntidade> BuscarTodos()
    {
        return _pacientes;
    }

    public void Inserir(PacienteEntidade paciente) { }

    public void Alterar(PacienteEntidade paciente) { }

    public void Excluir(PacienteEntidade paciente) { }

}
