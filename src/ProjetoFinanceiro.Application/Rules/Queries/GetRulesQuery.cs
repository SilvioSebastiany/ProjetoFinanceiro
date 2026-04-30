using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Rules.Queries;

public record GetRulesQuery : IRequest<IEnumerable<GetRulesResponse>>;

public record GetRulesResponse(Guid Id, string Keyword, WhoType Who);
