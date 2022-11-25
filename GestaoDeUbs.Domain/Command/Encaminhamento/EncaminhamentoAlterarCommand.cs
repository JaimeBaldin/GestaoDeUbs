using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Validation;

namespace GestaoDeUbs.Domain.Command.Encaminhamento;

public class EncaminhamentoAlterarCommand : Notificavel, ICommand
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string Observacoes { get; set; }
    public string DataEncaminhamento { get; set; }
    public int PacienteId { get; set; }
    public int HospitalId { get; set; }

    public EncaminhamentoAlterarCommand(int id, string nome, string observacoes, string dataEncaminhamento, int pacienteId, int hospitalId)
    {
        Id = id;
        Nome = nome;
        Observacoes = observacoes;
        DataEncaminhamento = dataEncaminhamento;
        PacienteId = pacienteId;
        HospitalId = hospitalId;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Id é obrigatório");
   

        if (string.IsNullOrEmpty(Observacoes))
            AdicionarNotificacao("O nome deve ser informado");

        if (PacienteId <= 0)
            AdicionarNotificacao("O paciente deve ser informado");

        if (HospitalId <= 0)
            AdicionarNotificacao("O paciente deve ser informado");
    }
}
