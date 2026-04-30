using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Rules.Commands;

public record CreateRuleCommand(string Keyword, WhoType Who) : IRequest<CreateRuleResponse>;

public record CreateRuleResponse(Guid Id, string Keyword, WhoType Who);
