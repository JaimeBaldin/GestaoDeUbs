using GestaoDeUbs.Domain.Command;
using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Command.Paciente;
using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Handlers.Interfaces;
using GestaoDeUbs.Domain.Repository;

namespace GestaoDeUbs.Domain.Handlers;

public class PacienteHandler : IHandler<PacienteInserirCommand>,IHandler<PacienteAlterarCommand>,IHandler<PacienteExcluirCommand>
    
{
    private readonly IPacienteRepositorio _pacienteRepositorio;

    public PacienteHandler(IPacienteRepositorio pacienteRepositorio)
    {
        _pacienteRepositorio = pacienteRepositorio;
    }

    #region Inserir
    public ICommandResult Handle(PacienteInserirCommand comando)
    {
        comando.Validar();
        if (comando.IsInvalida)
            return new CommandResult(false, "Erro ao inserir", comando.Notificacoes);

        var paciente = new PacienteEntidade(comando.Nome, comando.Rg, comando.Cpf, comando.Endereco, comando.DataNascimetno);

        _pacienteRepositorio.Inserir(paciente);

        return new CommandResult(true, "Paciente inserido com sucesso", paciente);
    }

    #endregion

    #region Alterar
    public ICommandResult Handle(PacienteAlterarCommand comando)
    {
        comando.Validar();
        if (comando.IsInvalida)
            return new CommandResult(false, "Erro ao alterar", comando.Notificacoes);

        var paciente = _pacienteRepositorio.BuscarPorId(comando.Id);

        if (paciente == null)
            return new CommandResult(false, "Paciente não encontrado", comando);

        paciente.Nome = comando.Nome;
        paciente.Cpf = comando.Cpf;
        paciente.Rg = comando.Rg;
        paciente.DataDeNascimento = comando.DataDeNascimetno;
        paciente.Endereco = comando.Endereco;

        _pacienteRepositorio.Alterar(paciente);

        return new CommandResult(true, "Paciente alterado com sucesso", paciente);
    }

    #endregion

    #region Excluir

    public ICommandResult Handle(PacienteExcluirCommand comando)
    {
        comando.Validar();
        if (comando.IsInvalida)
            return new CommandResult(false, "Erro ao excluir", comando.Notificacoes);

        var paciente = _pacienteRepositorio.BuscarPorId(comando.Id);

        if (paciente == null)
            return new CommandResult(false, "Paciente não encontrado", comando);

        _pacienteRepositorio.Excluir(paciente);

        return new CommandResult(true, "Paciente excluído com sucesso", paciente);
    }

    #endregion
}
