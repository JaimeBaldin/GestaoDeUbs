using GestaoDeUbs.Domain.Command;
using GestaoDeUbs.Domain.Command.Encaminhamento;
using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Handlers.Interfaces;
using GestaoDeUbs.Domain.Repository;

namespace GestaoDeUbs.Domain.Handlers;

public class EncaminhamentoHandler : IHandler<EncaminhamentoInserirCommand>, IHandler<EncaminhamentoAlterarCommand>, IHandler<EncaminhamentoExcluirCommand>
{
    private readonly IEncaminhamentoRepositorio _encaminhamentoRepositorio;

    public EncaminhamentoHandler(IEncaminhamentoRepositorio encaminhamentoRepositorio)
    {
        _encaminhamentoRepositorio = encaminhamentoRepositorio;
    }

    #region Inserir

    public ICommandResult Handle(EncaminhamentoInserirCommand comando)
    {
        comando.Validar();
        if (comando.IsInvalida)
            return new CommandResult(false, "Erro ao inserir", comando.Notificacoes);

        var encaminhamento = new EncaminhamentoEntidade(comando.Nome, comando.Observacoes, comando.Data, comando.PacienteId, comando.HospitalId);

        _encaminhamentoRepositorio.Inserir(encaminhamento);

        return new CommandResult(true, "Encaminhamento inserido com sucesso", encaminhamento);
    }

    #endregion

    #region Alterar

    public ICommandResult Handle(EncaminhamentoAlterarCommand comando)
    {
        comando.Validar();
        if (comando.IsInvalida)
            return new CommandResult(false, "Erro ao alterar", comando.Notificacoes);

        var encaminhamento = _encaminhamentoRepositorio.BuscarPorId(comando.Id);

        if (encaminhamento == null)
            return new CommandResult(false, "Encaminhamento não encontrado", comando);

        encaminhamento.Nome = comando.Nome;
        encaminhamento.Observacoes = comando.Observacoes;
        encaminhamento.DataEncaminhamento = comando.DataDeEncaminhamento;
        encaminhamento.PacienteId = comando.PacienteId;
        encaminhamento.HospitalId = comando.HospitalId;

        _encaminhamentoRepositorio.Alterar(encaminhamento);

        return new CommandResult(true, "Encaminhamento alterado com sucesso", encaminhamento);
    }

    #endregion

    #region Excluir

    public ICommandResult Handle(EncaminhamentoExcluirCommand comando)
    {
        comando.Validar();
        if (comando.IsInvalida)
            return new CommandResult(false, "Erro ao excluir", comando.Notificacoes);

        var encaminhamento = _encaminhamentoRepositorio.BuscarPorId(comando.Id);

        if (encaminhamento == null)
            return new CommandResult(false, "Encaminhamento não encontrado", comando);

        _encaminhamentoRepositorio.Excluir(encaminhamento);

        return new CommandResult(true, "Encaminhamento excluído com sucesso", encaminhamento);
    }

    #endregion
}
