using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Validation;

namespace GestaoDeUbs.Domain.Command.Encaminhamento;

public class EncaminhamentoExcluirCommand : Notificavel, ICommand
{
    public int Id { get; set; }

    public EncaminhamentoExcluirCommand(int id)
    {
        Id = id;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Id é obrigatório");
    }
}
