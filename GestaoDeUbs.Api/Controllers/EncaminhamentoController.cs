using GestaoDeUbs.Domain.Command;
using GestaoDeUbs.Domain.Command.Encaminhamento;
using GestaoDeUbs.Domain.Handlers;
using GestaoDeUbs.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeUbs.Api.Controllers;

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

}
