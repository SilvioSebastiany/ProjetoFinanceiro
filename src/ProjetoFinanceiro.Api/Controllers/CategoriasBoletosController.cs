using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Application.BoletoCategories.Commands;
using ProjetoFinanceiro.Application.BoletoCategories.Queries;

namespace ProjetoFinanceiro.Api.Controllers;

[ApiController]
[Route("categorias-boleto")]
public class CategoriasBoletosController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriasBoletosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBoletoCategoriesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBoletoCategoryCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var found = await _mediator.Send(new DeleteBoletoCategoryCommand(id), cancellationToken);
        return found ? NoContent() : NotFound();
    }
}
