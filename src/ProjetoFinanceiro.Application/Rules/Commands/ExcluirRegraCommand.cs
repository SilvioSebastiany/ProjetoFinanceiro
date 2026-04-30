using MediatR;

namespace ProjetoFinanceiro.Application.Rules.Commands;

public record ExcluirRegraCommand(Guid Id) : IRequest<bool>;
