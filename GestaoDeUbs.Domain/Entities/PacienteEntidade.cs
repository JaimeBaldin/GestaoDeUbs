namespace GestaoDeUbs.Domain.Entities;

public class PacienteEntidade : Entidade
{
    public string Nome { get; set; }
    public string Rg { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }
    public string DataDeNascimento { get; set; }

    public IList<EncaminhamentoEntidade> Encaminhamentos { get; set; }

    public PacienteEntidade(string nome, string rg, string cpf, string endereco, string dataDeNascimento)
    {
        Nome = nome;
        Rg = rg;
        Cpf = cpf;
        Endereco = endereco;
        DataDeNascimento = dataDeNascimento;
        Encaminhamentos = new List<EncaminhamentoEntidade>();
    }

    public PacienteEntidade(int id, string nome, string rg, string cpf, string endereco, string dataDeNascimento)
    {
        Id = id;
        Nome = nome;
        Rg = rg;
        Cpf = cpf;
        Endereco = endereco;
        DataDeNascimento = dataDeNascimento;
        Encaminhamentos = new List<EncaminhamentoEntidade>();
    }
}
