using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Validation;

namespace GestaoDeUbs.Domain.Command.Paciente;

public class PacienteExcluirCommand : Notificavel, ICommand
{
    public int Id { get; set; }

    public PacienteExcluirCommand(int id)
    {
        Id = id;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Id inválido");
    }
}
