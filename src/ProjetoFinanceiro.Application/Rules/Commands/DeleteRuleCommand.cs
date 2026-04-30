using MediatR;

namespace ProjetoFinanceiro.Application.Rules.Commands;

public record DeleteRuleCommand(Guid Id) : IRequest<bool>;
