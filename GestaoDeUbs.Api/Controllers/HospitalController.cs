using GestaoDeUbs.Domain.Command;
using GestaoDeUbs.Domain.Command.Hospital;
using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Handlers;
using GestaoDeUbs.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeUbs.Api.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class HospitalController : ControllerBase
{
    private readonly IHospitalRepositorio _repositorio;

    public HospitalController(IHospitalRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    #region Inserir

    [HttpPost]
    public CommandResult Inserir(HospitalInserirCommand command,
        [FromServices] HospitalHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }

    #endregion

    #region Alterar

    [HttpPut]
    public CommandResult Alterar(HospitalAlterarCommand command,
        [FromServices] HospitalHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }

    #endregion

    #region Excluir

    [HttpDelete]
    public CommandResult Excluir(HospitalExcluirCommand command,
        [FromServices] HospitalHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }

    #endregion

    #region BuscarPorId

    [HttpGet("{id}")]
    public HospitalEntidade? BuscaPorId(int id)
    {
        return _repositorio.BuscarPorId(id);
    }

    #endregion

    #region BuscarTodos
    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<HospitalEntidade> BuscarTodos([FromServices] IHospitalRepositorio repositorio)
    {
        return repositorio.BuscarTodos();
    }

    #endregion 
}
