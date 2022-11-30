using GestaoDeUbs.Domain.Repository;
using GestaoUbs.Tests.Repositories;

namespace GestaoUbs.Tests.Queries;
[TestClass]
public class HospitalQuerieTests
{
    private IHospitalRepositorio _repositorio;

    public HospitalQuerieTests()
    {
        _repositorio = new MockHospitalRepository();
    }

    [TestMethod]
    public void DeveRetornarHospitalPorId()
    {
        var result = _repositorio.BuscarPorId(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }

    [TestMethod]
    public void DeveRetornarNullQuandoHospitalNaoExiste()
    {
        var result = _repositorio.BuscarPorId(3);

        Assert.IsNull(result);
    }
}
