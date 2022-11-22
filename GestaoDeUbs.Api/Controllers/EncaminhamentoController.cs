using GestaoDeUbs.Domain.Command;
using GestaoDeUbs.Domain.Command.Encaminhamento;
using GestaoDeUbs.Domain.Entities;
using GestaoDeUbs.Domain.Handlers;
using GestaoDeUbs.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeUbs.Api.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class EncaminhamentoController : ControllerBase
{
    private readonly IEncaminhamentoRepositorio _repositorio;
    private readonly EncaminhamentoHandler _handler;

    public EncaminhamentoController(IEncaminhamentoRepositorio repositorio, EncaminhamentoHandler handler)
    {
        _repositorio = repositorio;
        _handler = handler;
    }

    #region Inserir

    [HttpPost]
    public CommandResult Inserir(EncaminhamentoInserirCommand comando)
    {
        return (CommandResult)_handler.Handle(comando);
    }


    #endregion

    #region Alterar

    [HttpPut]
    public CommandResult Alterar(EncaminhamentoAlterarCommand comando)
    {
        return (CommandResult)_handler.Handle(comando);
    }

    #endregion

    #region Excluir

    [HttpDelete]
    public CommandResult Excluir(EncaminhamentoExcluirCommand comando)
    {
        return (CommandResult)_handler.Handle(comando);
    }

    #endregion

    #region BuscarPorId

    [HttpGet("{id}")]
    public EncaminhamentoEntidade BuscarPorId(int id)
    {
        return _repositorio.BuscarPorId(id);
    }

    #endregion

    #region BuscarTodos
    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<EncaminhamentoEntidade> BuscarTodos()
    {
        return _repositorio.BuscarTodos();
    }

    #endregion
    
    #region BuscarPorPaciente

    [HttpGet("paciente/{id}")]
    public IEnumerable<EncaminhamentoEntidade> BuscarPorPaciente(int pacienteId)
    {
        return _repositorio.BuscarPorPaciente(pacienteId);
    }

    #endregion

    #region BuscarPorHospital

    [HttpGet("hospital/{id}")]
    public IEnumerable<EncaminhamentoEntidade> BuscarPorHospital(int hospitalId)
    {
        return _repositorio.BuscarPorHospital(hospitalId);
    }

    #endregion

}
