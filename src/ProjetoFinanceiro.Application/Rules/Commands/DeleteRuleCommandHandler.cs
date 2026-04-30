using MediatR;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Rules.Commands;

public class DeleteRuleCommandHandler : IRequestHandler<DeleteRuleCommand, bool>
{
    private readonly IFinanceiroDbContext _db;

    public DeleteRuleCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(DeleteRuleCommand request, CancellationToken cancellationToken)
    {
        var rule = await _db.Rules.FindAsync([request.Id], cancellationToken);
        if (rule is null) return false;

        _db.Rules.Remove(rule);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
