using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Handlers.Criptografia;
using GestaoDeUbs.Domain.Validation;

namespace GestaoDeUbs.Domain.Command.Paciente;

public class PacienteAlterarCommand : Notificavel, ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Rg { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }
    public string DataDeNascimento { get; set; }


    public PacienteAlterarCommand(int id, string nome, string rg, string cpf, string endereco, string dataDeNascimento)
    {
        Id = id;
        Nome = nome;
        Rg = Criptografia.AesEncrypt(rg);
        Cpf = Criptografia.AesEncrypt(cpf);
        Endereco = Criptografia.AesEncrypt(endereco);
        DataDeNascimento = dataDeNascimento;
    }




    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Id inválido");

        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("Por favor informar o nome");

        if (string.IsNullOrEmpty(Rg))
            AdicionarNotificacao("Por favor informar o RG");

        if (string.IsNullOrEmpty(Cpf))
            AdicionarNotificacao("Por favor informar o CPF");

        if (string.IsNullOrEmpty(Endereco))
            AdicionarNotificacao("Por favor informar o Endereço");
        

    }
}
