using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Validation;

namespace GestaoDeUbs.Domain.Command.Encaminhamento;

public class EncaminhamentoInserirCommand : Notificavel, ICommand
{
    public string? Nome { get; set; }
    public string Observacoes { get; set; }
    public string Data { get; set; }
    public int PacienteId { get; set; }
    public int HospitalId { get; set; }

    public EncaminhamentoInserirCommand(string nome, string observacoes, string data, int pacienteId, int hospitalId)
    {
        Nome = nome;
        Observacoes = observacoes;
        Data = data;
        PacienteId = pacienteId;
        HospitalId = hospitalId;
    }

    public void Validar()
    {

        if (string.IsNullOrEmpty(Observacoes))
            AdicionarNotificacao("O nome deve ser informado");

        if (PacienteId <= 0)
            AdicionarNotificacao("O paciente deve ser informado");

        if (HospitalId <= 0)
            AdicionarNotificacao("O paciente deve ser informado");
    }
}
