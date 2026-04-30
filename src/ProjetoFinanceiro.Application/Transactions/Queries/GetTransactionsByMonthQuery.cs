using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Queries;

public record GetTransactionsByMonthQuery(Guid MonthId) : IRequest<IEnumerable<GetTransactionsByMonthResponse>>;

public record GetTransactionsByMonthResponse(
    Guid Id,
    DateOnly Date,
    string Description,
    decimal Amount,
    WhoType Who,
    CardOwnerType CardOwner,
    DateTime CreatedAt);
