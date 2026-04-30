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
    public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
    {
        var resultado = await _mediator.Send(new BuscarRegrasQuery(), cancellationToken);
        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarRegraCommand command, CancellationToken cancellationToken)
    {
        var resultado = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(BuscarTodos), new { id = resultado.Id }, resultado);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Excluir(Guid id, CancellationToken cancellationToken)
    {
        var encontrado = await _mediator.Send(new ExcluirRegraCommand(id), cancellationToken);
        return encontrado ? NoContent() : NotFound();
    }
}
