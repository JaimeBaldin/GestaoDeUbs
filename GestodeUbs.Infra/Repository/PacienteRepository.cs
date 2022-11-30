using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Handlers.Criptografia;
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

        var dados = _contexto.Pacientes
           .Where(PacienteQueries.BuscarPorId(id))
           .FirstOrDefault();

        dados.Cpf = Criptografia.AesDecrypt(dados.Cpf);
        dados.Rg = Criptografia.AesDecrypt(dados.Rg);
        dados.Endereco = Criptografia.AesDecrypt(dados.Endereco);


        return dados;

    }

    public IEnumerable<PacienteEntidade> BuscarTodos()
    {
        var dados = _contexto.Pacientes.ToList();

        foreach (var item in dados)
        {
            item.Cpf = Criptografia.AesDecrypt(item.Cpf);
            item.Rg = Criptografia.AesDecrypt(item.Rg);
            item.Endereco = Criptografia.AesDecrypt(item.Endereco);
        }

        return dados;

    }
}
