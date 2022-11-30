using GestaoDeUbs.Domain.Command.Interfaces;
using GestaoDeUbs.Domain.Handlers.Criptografia;
using GestaoDeUbs.Domain.Validation;
using Microsoft.VisualBasic;

namespace GestaoDeUbs.Domain.Command.Paciente;

public class PacienteInserirCommand : Notificavel, ICommand
{
    public string Nome { get; set; }
    public string Rg { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }
    public string  DataNascimetno { get; set; }

    public PacienteInserirCommand(string nome, string rg, string cpf,string endereco, string dataNascimetno)
    {
        Nome = nome;
        Rg = Criptografia.AesEncrypt(rg);
        Cpf = Criptografia.AesEncrypt(cpf);
        Endereco = Criptografia.AesEncrypt(endereco);
        DataNascimetno = dataNascimetno;
    }

    public PacienteInserirCommand() { }


    public void Validar()
    {
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
