using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Application.Rules.Commands;
using ProjetoFinanceiro.Application.Rules.Queries;

namespace ProjetoFinanceiro.Api.Controllers;

[ApiController]
[Route("regras")]
public class RegrasController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegrasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetRulesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRuleCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var found = await _mediator.Send(new DeleteRuleCommand(id), cancellationToken);
        return found ? NoContent() : NotFound();
    }
}
