using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public record AtualizarResponsavelTransacaoCommand(Guid Id, TipoResponsavel Responsavel) : IRequest<bool>;
