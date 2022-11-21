using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Validation;

namespace GestaoDeUbs.Domain.Command.Hospital;

public class HospitalAlterarCommand : Notificavel, ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Especialidades { get; set; }

    public HospitalAlterarCommand(int id, string nome, string endereco, string especialidades)
    {
        Id = id;
        Nome = nome;
        Endereco = endereco;
        Especialidades = especialidades;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");

        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("Por favor informar o Nome");

        if (string.IsNullOrEmpty(Especialidades))
            AdicionarNotificacao("Por favor informar o Especialidades");

        if (string.IsNullOrEmpty(Endereco))
            AdicionarNotificacao("Por favor informar o Endereco");

    }
}
