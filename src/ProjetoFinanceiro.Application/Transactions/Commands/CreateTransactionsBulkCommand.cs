using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public record CreateTransactionsBulkCommand(
    Guid MonthId,
    List<CreateTransactionsBulkItem> Items) : IRequest<IEnumerable<CreateTransactionResponse>>;

public record CreateTransactionsBulkItem(
    DateOnly Date,
    string Description,
    decimal Amount,
    CardOwnerType CardOwner);
