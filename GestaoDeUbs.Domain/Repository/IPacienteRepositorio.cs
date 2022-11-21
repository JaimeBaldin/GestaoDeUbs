using GestaoDeUbs.Domain.Entities;

namespace GestaoDeUbs.Domain.Repository;

public interface IPacienteRepositorio
{
    void Inserir(PacienteEntidade paciente);
    void Alterar(PacienteEntidade paciente);
    void Excluir(PacienteEntidade paciente);
    IEnumerable<PacienteEntidade> BuscarTodos();
    PacienteEntidade? BuscarPorId(int id);
}
