using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public record DeleteTransactionsByCardOwnerCommand(Guid MonthId, CardOwnerType CardOwner) : IRequest;
