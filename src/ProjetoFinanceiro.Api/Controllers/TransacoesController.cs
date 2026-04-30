using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Application.Transactions.Commands;
using ProjetoFinanceiro.Application.Transactions.Queries;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Api.Controllers;

[ApiController]
[Route("meses/{mesId}/transacoes")]
public class TransacoesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransacoesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarPorMes(Guid mesId, CancellationToken cancellationToken)
    {
        var resultado = await _mediator.Send(new BuscarTransacoesPorMesQuery(mesId), cancellationToken);
        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Guid mesId, CriarTransacaoCommand command, CancellationToken cancellationToken)
    {
        var commandComMes = command with { MesId = mesId };
        var resultado = await _mediator.Send(commandComMes, cancellationToken);
        return CreatedAtAction(nameof(BuscarPorMes), new { mesId = resultado.MesId }, resultado);
    }

    [HttpPost("lote")]
    public async Task<IActionResult> CriarEmLote(Guid mesId, CriarTransacoesEmLoteCommand command, CancellationToken cancellationToken)
    {
        var commandComMes = command with { MesId = mesId };
        var resultado = await _mediator.Send(commandComMes, cancellationToken);
        return Ok(resultado);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> AtualizarResponsavel(Guid mesId, Guid id, [FromBody] AtualizarResponsavelRequest body, CancellationToken cancellationToken)
    {
        var encontrado = await _mediator.Send(new AtualizarResponsavelTransacaoCommand(id, body.Responsavel), cancellationToken);
        return encontrado ? NoContent() : NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> ExcluirPorDono(Guid mesId, [FromQuery] TipoDono dono, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ExcluirTransacoesPorDonoCommand(mesId, dono), cancellationToken);
        return NoContent();
    }
}

public record AtualizarResponsavelRequest(TipoResponsavel Responsavel);
