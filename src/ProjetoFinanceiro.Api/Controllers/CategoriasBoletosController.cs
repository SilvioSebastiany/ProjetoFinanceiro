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
    public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
    {
        var resultado = await _mediator.Send(new BuscarCategoriasBoletoQuery(), cancellationToken);
        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarCategoriaBoletoCommand command, CancellationToken cancellationToken)
    {
        var resultado = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(BuscarTodos), new { id = resultado.Id }, resultado);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Excluir(Guid id, CancellationToken cancellationToken)
    {
        var encontrado = await _mediator.Send(new ExcluirCategoriaBoletoCommand(id), cancellationToken);
        return encontrado ? NoContent() : NotFound();
    }
}
