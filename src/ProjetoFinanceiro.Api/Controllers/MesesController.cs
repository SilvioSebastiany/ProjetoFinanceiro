using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Application.Months.Commands;
using ProjetoFinanceiro.Application.Months.Queries;

namespace ProjetoFinanceiro.Api.Controllers;

[ApiController]
[Route("meses")]
public class MesesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MesesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
    {
        var resultado = await _mediator.Send(new BuscarMesesQuery(), cancellationToken);
        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarMesCommand command, CancellationToken cancellationToken)
    {
        var resultado = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(BuscarTodos), new { id = resultado.Id }, resultado);
    }
}
