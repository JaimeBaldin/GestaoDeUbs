using GestaoDeUbs.Domain.Entities;

namespace GestaoDeUbs.Domain.Repository;

public interface IEncaminhamentoRepositorio
{
    void Inserir(EncaminhamentoEntidade encaminhamento);
    void Alterar(EncaminhamentoEntidade encaminhamento);
    void Excluir(EncaminhamentoEntidade encaminhamento);
    IEnumerable<EncaminhamentoEntidade> BuscarTodos();
    EncaminhamentoEntidade? BuscarPorId(int id);
}
