using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Application.Boletos.Commands;
using ProjetoFinanceiro.Application.Boletos.Queries;

namespace ProjetoFinanceiro.Api.Controllers;

[ApiController]
[Route("meses/{mesId}/boletos")]
public class BoletosController : ControllerBase
{
    private readonly IMediator _mediator;

    public BoletosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetByMes(Guid mesId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBoletosByMonthQuery(mesId), cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Save(Guid mesId, SaveBoletosCommand command, CancellationToken cancellationToken)
    {
        var commandWithMes = command with { MonthId = mesId };
        var result = await _mediator.Send(commandWithMes, cancellationToken);
        return Ok(result);
    }
}
