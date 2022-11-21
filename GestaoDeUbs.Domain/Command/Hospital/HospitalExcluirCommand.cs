using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Validation;

namespace GestaoDeUbs.Domain.Command.Hospital;

public class HospitalExcluirCommand : Notificavel, ICommand
{
    public int Id { get; set; }

    public HospitalExcluirCommand(int id)
    {
        Id = id;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");
    }
}
