using MediatR;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Rules.Commands;

public class CreateRuleCommandHandler : IRequestHandler<CreateRuleCommand, CreateRuleResponse>
{
    private readonly IFinanceiroDbContext _db;

    public CreateRuleCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<CreateRuleResponse> Handle(CreateRuleCommand request, CancellationToken cancellationToken)
    {
        var rule = new Rule
        {
            Id = Guid.NewGuid(),
            Keyword = request.Keyword,
            Who = request.Who,
            CreatedAt = DateTime.UtcNow
        };

        _db.Rules.Add(rule);
        await _db.SaveChangesAsync(cancellationToken);

        return new CreateRuleResponse(rule.Id, rule.Keyword, rule.Who);
    }
}
