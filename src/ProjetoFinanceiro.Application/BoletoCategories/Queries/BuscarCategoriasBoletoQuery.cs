using MediatR;

namespace ProjetoFinanceiro.Application.BoletoCategories.Queries;

public record BuscarCategoriasBoletoQuery : IRequest<IEnumerable<BuscarCategoriasBoletoResponse>>;

public record BuscarCategoriasBoletoResponse(Guid Id, string Nome);
