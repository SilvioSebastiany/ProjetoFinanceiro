using MediatR;

namespace ProjetoFinanceiro.Application.BoletoCategories.Queries;

public record GetBoletoCategoriesQuery : IRequest<IEnumerable<GetBoletoCategoriesResponse>>;

public record GetBoletoCategoriesResponse(Guid Id, string Name);
