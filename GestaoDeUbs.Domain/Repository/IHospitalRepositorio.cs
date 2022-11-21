using GestaoDeUbs.Domain.Entities;

namespace GestaoDeUbs.Domain.Repository;

public interface IHospitalRepositorio
{
    void Inserir(HospitalEntidade hospital);
    void Alterar(HospitalEntidade hospital);
    void Excluir(HospitalEntidade hospital);
    IEnumerable<HospitalEntidade> BuscarTodos();
    HospitalEntidade? BuscarPorId(int id);
}
