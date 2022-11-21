namespace GestaoDeUbs.Domain.Entities;

public class HospitalEntidade : Entidade
{
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Especialidades { get; set; }

    public IList<EncaminhamentoEntidade> Encaminhamentos { get; set; }

    public HospitalEntidade(string nome, string endereco, string especialidades)
    {
        Nome = nome;
        Endereco = endereco;
        Especialidades = especialidades;
        Encaminhamentos = new List<EncaminhamentoEntidade>();
    }

    public HospitalEntidade(int id, string nome, string endereco, string especialidades)
    {
        Id = id;
        Nome = nome;
        Endereco = endereco;
        Especialidades = especialidades;
        Encaminhamentos = new List<EncaminhamentoEntidade>();
    }
}
