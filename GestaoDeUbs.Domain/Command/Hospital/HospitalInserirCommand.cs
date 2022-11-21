using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Validation;

namespace GestaoDeUbs.Domain.Command.Hospital;

public class HospitalInserirCommand : Notificavel, ICommand
{
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Especialidades { get; set; }

    public HospitalInserirCommand(string nome, string endereco, string especialidades)
    {
        Nome = nome;
        Endereco = endereco;
        Especialidades = especialidades;
    }

    public void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("Por favor informar o nome");

        if (string.IsNullOrEmpty(Especialidades))
            AdicionarNotificacao("Por favor informar o especialidades");

        if (string.IsNullOrEmpty(Endereco))
            AdicionarNotificacao("Por favor informar o endereco");
    }
}
