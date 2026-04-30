using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public record CreateTransactionCommand(
    DateOnly Date,
    string Description,
    decimal Amount,
    Guid MonthId) : IRequest<CreateTransactionResponse>;

public record CreateTransactionResponse(
    Guid Id,
    DateOnly Date,
    string Description,
    decimal Amount,
    WhoType Who,
    Guid MonthId,
    DateTime CreatedAt);
