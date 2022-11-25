using GestaoDeUbs.Domain.Command;
using GestaoDeUbs.Domain.Command.Paciente;
using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Handlers;
using GestaoDeUbs.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeUbs.Api.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
 
    
    private readonly IPacienteRepositorio _repositorio;

    public PacienteController(IPacienteRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    #region Inserir
    [HttpPost]
    public CommandResult Inserir(PacienteInserirCommand comando,
        [FromServices] PacienteHandler handler)
    {
        return (CommandResult)handler.Handle(comando);
    }
    #endregion

    #region Alterar
    [HttpPut]
    public CommandResult Alterar(PacienteAlterarCommand comando,
        [FromServices] PacienteHandler handler)
    {
        return (CommandResult)handler.Handle(comando);
    }

    #endregion

    #region Excluir
    [HttpDelete]
    public CommandResult Excluir(PacienteExcluirCommand comando,
        [FromServices] PacienteHandler handler)
    {
        return (CommandResult)handler.Handle(comando);
    }

    #endregion

    #region BuscarPorId

    [HttpGet("{id}")]
    public PacienteEntidade? BuscarPorId(int id)
    {
        return _repositorio.BuscarPorId(id);
    }

    #endregion

    #region BuscarTodos
    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<PacienteEntidade> BuscarTodos([FromServices] IPacienteRepositorio repositorio)
    {
        return repositorio.BuscarTodos();
    }
    #endregion
}
