using GestaoDeUbs.Domain.Command.Interfaces;

namespace GestaoDeUbs.Domain.Command;

public class CommandResult : ICommandResult
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public object Dados { get; set; }

    public CommandResult(bool sucesso, string mensagem, object dados)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
        Dados = dados;
    }

    public CommandResult() { }
}
