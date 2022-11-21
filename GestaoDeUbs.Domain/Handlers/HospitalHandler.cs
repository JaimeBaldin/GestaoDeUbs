using GestaoDeUbs.Domain.Command;
using GestaoDeUbs.Domain.Command.Hospital;
using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Handlers.Interfaces;
using GestaoDeUbs.Domain.Repository;

namespace GestaoDeUbs.Domain.Handlers;

public class HospitalHandler : IHandler<HospitalInserirCommand>, IHandler<HospitalAlterarCommand>, IHandler<HospitalExcluirCommand>
{
    private readonly IHospitalRepositorio _hospitalRepositorio;

    public HospitalHandler(IHospitalRepositorio hospitalRepositorio)
    {
        _hospitalRepositorio = hospitalRepositorio;
    }


    #region Inserir

    public ICommandResult Handle(HospitalInserirCommand comando)
    {
        comando.Validar();
        if (comando.IsInvalida)
            return new CommandResult(false, "Erro ao inserir", comando.Notificacoes);

        var hospital = new HospitalEntidade(comando.Nome, comando.Endereco, comando.Especialidades);

        _hospitalRepositorio.Inserir(hospital);

        return new CommandResult(true, "Hospital inserido com sucesso", hospital);
    }

    #endregion

    #region Alterar

    public ICommandResult Handle(HospitalAlterarCommand comando)
    {
        comando.Validar();
        if (comando.IsInvalida)
            return new CommandResult(false, "Erro ao alterar", comando.Notificacoes);

        var hospital = _hospitalRepositorio.BuscarPorId(comando.Id);

        if (hospital == null)
            return new CommandResult(false, "Hospital não encontrado", comando);

        hospital.Nome = comando.Nome;
        hospital.Endereco = comando.Endereco;
        hospital.Especialidades = comando.Especialidades;

        _hospitalRepositorio.Alterar(hospital);

        return new CommandResult(true, "Hospital alterado com sucesso", hospital);
    }

    #endregion

    #region Excluir

    public ICommandResult Handle(HospitalExcluirCommand comando)
    {
        comando.Validar();
        if (comando.IsInvalida)
            return new CommandResult(false, "Erro ao excluir", comando.Notificacoes);

        var hospital = _hospitalRepositorio.BuscarPorId(comando.Id);

        if (hospital == null)
            return new CommandResult(false, "Hospital não encontrado", comando);

        _hospitalRepositorio.Excluir(hospital);

        return new CommandResult(true, "Hospital excluído com sucesso", hospital);
    }

    #endregion
}
