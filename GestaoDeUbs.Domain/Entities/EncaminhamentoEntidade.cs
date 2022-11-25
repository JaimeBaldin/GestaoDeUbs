namespace GestaoDeUbs.Domain.Entities;

public class EncaminhamentoEntidade : Entidade
{
    public string? Nome { get; set; }
    public string Observacoes { get; set; }
    public string DataEncaminhamento { get; set; }
    public int PacienteId { get; set; }
    public int HospitalId { get; set; }
    public PacienteEntidade Paciente { get; set; }
    public HospitalEntidade Hospital { get; set; }


    public EncaminhamentoEntidade(string nome, string observacoes, string dataEncaminhamento, int pacienteId, int hospitalId)
    {
        Nome = nome;
        Observacoes = observacoes;
        DataEncaminhamento = dataEncaminhamento;
        PacienteId = pacienteId;
        HospitalId = hospitalId;
    }

    public EncaminhamentoEntidade(int id, string nome, string observacoes, string dataEncaminhamento, int pacienteId, int hospitalId)
    {
        Id = id;
        Nome = nome;
        Observacoes = observacoes;
        DataEncaminhamento = dataEncaminhamento;
        PacienteId = pacienteId;
        HospitalId = hospitalId;
    }
}
