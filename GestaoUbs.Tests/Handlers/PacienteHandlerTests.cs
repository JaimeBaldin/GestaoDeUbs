using GestaoDeUbs.Domain.Command;
using GestaoDeUbs.Domain.Command.Paciente;
using GestaoDeUbs.Domain.Handlers;
using GestaoDeUbs.Domain.Repository;
using GestaoUbs.Tests.Repositories;

namespace GestaoUbs.Tests.Handlers;

[TestClass]
public class PacienteHandlerTests
{
    private IPacienteRepositorio _repositorio;
    private PacienteHandler _handler;

    public PacienteHandlerTests()
    {
        _repositorio = new MockPacienteRepository();
        _handler = new PacienteHandler(_repositorio);
    }

    [TestMethod]
    public void DadoUmComandoInserirValidoRetornaSucessoTrue()
    {
        var command = new PacienteInserirCommand("Jaime","107279571","07454962952","rua x","18111991");

        var result = _handler.Handle(command);

        Assert.IsTrue((result as CommandResult).Sucesso);
    } 

    [TestMethod]
    public void DadoUmComandoInserirInvalidoRetornaSucessoFalse()
    {
        var command = new PacienteInserirCommand();

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoAlterarValidoDeveRetornarSucessoTrue()
    {
        var command = new PacienteAlterarCommand(1,"Jaime", "107279571", "07454962952", "rua x", "18111991");

        var result = _handler.Handle(command);

        Assert.IsTrue((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoAlterarInvalidoDeveRetornarSucessoFalse()
    {
        var command = new PacienteAlterarCommand(0, "Jaime", "107279571", "07454962952", "rua x", "18111991");

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoAlterarValidoMasComPacienteInexistenteDeveRetornarSucessoFalse()
    {
        var command = new PacienteAlterarCommand(9, "Jaime", "107279571", "07454962952", "rua x", "18111991");

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoExcluirValidoDeveRetornarSucessoTrue()
    {
        var command = new PacienteExcluirCommand(1);

        var result = _handler.Handle(command);

        Assert.IsTrue((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoExcluirInvalidoDeveRetornarSucessoFalse()
    {
        var command = new PacienteExcluirCommand();

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoExcluirValidoMasComEditoraInexistenteDeveRetornarSucessoFalse()
    {
        var command = new PacienteExcluirCommand(9);

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

}
