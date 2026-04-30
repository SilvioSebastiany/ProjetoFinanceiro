using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public record ExcluirTransacoesPorDonoCommand(Guid MesId, TipoDono Dono) : IRequest;
