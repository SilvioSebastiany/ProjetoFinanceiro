using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public record CreateTransactionCommand(
    DateOnly Date,
    string Description,
    decimal Amount,
    CardOwnerType CardOwner,
    Guid MonthId) : IRequest<CreateTransactionResponse>;

public record CreateTransactionResponse(
    Guid Id,
    DateOnly Date,
    string Description,
    decimal Amount,
    WhoType Who,
    CardOwnerType CardOwner,
    Guid MonthId,
    DateTime CreatedAt);
