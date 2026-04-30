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
    public async Task<IActionResult> BuscarPorMes(Guid mesId, CancellationToken cancellationToken)
    {
        var resultado = await _mediator.Send(new BuscarBoletosPorMesQuery(mesId), cancellationToken);
        return Ok(resultado);
    }

    [HttpPut]
    public async Task<IActionResult> Salvar(Guid mesId, SalvarBoletosCommand command, CancellationToken cancellationToken)
    {
        var commandComMes = command with { MesId = mesId };
        var resultado = await _mediator.Send(commandComMes, cancellationToken);
        return Ok(resultado);
    }
}
