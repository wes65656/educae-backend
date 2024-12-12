using educae.contas.app.Models;
using educae.contas.app.Application.Commands.Educadores;
using educae.contas.app.Application.Queries.Interfaces;
using educae.contas.domain.enums;
using EstartandoDevsCore.Mediator;
using EstartandoDevsCore.ValueObjects;
using EstartandoDevsWebApiCore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

[Route("api/[controller]")]
public class EducadoresController : MainController
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IEducadorQuery _educadorQuery;

    public EducadoresController(IMediatorHandler mediatorHandler, IEducadorQuery educadorQuery)
    {
        _mediatorHandler = mediatorHandler;
        _educadorQuery = educadorQuery;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] EducadorModel model)
    {
        var command = new CadastrarEducadorCommand(
            model.Nome, 
            new Email(model.Email), 
            new Senha(model.Senha), 
            (TipoUsuario)model.TipoUsuario, 
            model.Telefone, 
            model.Cpf
        );
        return CustomResponse(await _mediatorHandler.EnviarComando(command));
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] EducadorModel model)
    {
        var command = new AtualizarEducadorCommand(
            model.Nome, 
            new Email(model.Email), 
            new Senha(model.Senha), 
            (TipoUsuario)model.TipoUsuario, 
            model.Telefone, 
            model.Cpf
        );
        return CustomResponse(await _mediatorHandler.EnviarComando(command));
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> ObterPorCpf(string cpf)
    {
        var educador = await _educadorQuery.ObterEducadorPorCpf(cpf);
        if (educador == null) return NotFound();
        return CustomResponse(educador);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        return CustomResponse(await _educadorQuery.ObterEducadores());
    }
}