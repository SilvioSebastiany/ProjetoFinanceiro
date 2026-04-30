using MediatR;

namespace ProjetoFinanceiro.Application.Months.Queries;

public record GetMonthsQuery : IRequest<IEnumerable<GetMonthsResponse>>;

public record GetMonthsResponse(Guid Id, string Label, DateTime CreatedAt);
