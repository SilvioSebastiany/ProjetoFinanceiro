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
    public async Task<IActionResult> GetByMes(Guid mesId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTransactionsByMonthQuery(mesId), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Guid mesId, CreateTransactionCommand command, CancellationToken cancellationToken)
    {
        var commandWithMes = command with { MonthId = mesId };
        var result = await _mediator.Send(commandWithMes, cancellationToken);
        return CreatedAtAction(nameof(GetByMes), new { mesId = result.MonthId }, result);
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> CreateBulk(Guid mesId, CreateTransactionsBulkCommand command, CancellationToken cancellationToken)
    {
        var commandWithMes = command with { MonthId = mesId };
        var result = await _mediator.Send(commandWithMes, cancellationToken);
        return Ok(result);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PatchWho(Guid mesId, Guid id, [FromBody] PatchTransactionWhoRequest body, CancellationToken cancellationToken)
    {
        var found = await _mediator.Send(new PatchTransactionWhoCommand(id, body.Who), cancellationToken);
        return found ? NoContent() : NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteByCardOwner(Guid mesId, [FromQuery] CardOwnerType cardOwner, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteTransactionsByCardOwnerCommand(mesId, cardOwner), cancellationToken);
        return NoContent();
    }
}

public record PatchTransactionWhoRequest(WhoType Who);
