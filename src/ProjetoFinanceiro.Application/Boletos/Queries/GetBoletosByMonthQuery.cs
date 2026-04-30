using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Boletos.Queries;

public record GetBoletosByMonthQuery(Guid MonthId) : IRequest<IEnumerable<GetBoletosByMonthResponse>>;

public record GetBoletosByMonthResponse(Guid Id, string Name, decimal Amount, WhoType Who);
