using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public record PatchTransactionWhoCommand(Guid Id, WhoType Who) : IRequest<bool>;
