using GestaoDeUbs.Domain.Repository;
using GestaoUbs.Tests.Repositories;

namespace GestaoUbs.Tests.Queries;
[TestClass]
public class PacienteQuerieTests
{
    private IPacienteRepositorio _repositorio;

    public PacienteQuerieTests()
    {
        _repositorio = new MockPacienteRepository();
    }

    [TestMethod]
    public void DeveRetornarPacientePorId()
    {
        var result = _repositorio.BuscarPorId(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }

    [TestMethod]
    public void DeveRetornarNullQuandoPacienteNaoExiste()
    {
        var result = _repositorio.BuscarPorId(3);

        Assert.IsNull(result);
    }
}
