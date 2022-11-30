using GestaoDeUbs.Domain.Repository;
using GestaoUbs.Tests.Repositories;

namespace GestaoUbs.Tests.Queries;
[TestClass]
public class EncaminhamentoQuerieTests
{
    private IEncaminhamentoRepositorio _repositorio;

    public EncaminhamentoQuerieTests()
    {
        _repositorio = new MockEncaminhamentoRepository();
    }

    [TestMethod]
    public void DeveRetornarEncaminhamentoPorId()
    {
        var result = _repositorio.BuscarPorId(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }

    [TestMethod]
    public void DeveRetornarNullQuandoEncaminhamentoNaoExiste()
    {
        var result = _repositorio.BuscarPorId(3);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void DeveRetornarEncaminhamentosPorPaciente()
    {
        var result = _repositorio.BuscarPorPaciente(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count());
    }


    [TestMethod]
    public void DeveRetornarEncaminhamentosPorHospital()
    {
        var result = _repositorio.BuscarPorHospital(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count());
    }

   



}
