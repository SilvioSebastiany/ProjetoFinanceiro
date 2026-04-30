using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Rules.Queries;

public class GetRulesQueryHandler : IRequestHandler<GetRulesQuery, IEnumerable<GetRulesResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public GetRulesQueryHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetRulesResponse>> Handle(GetRulesQuery request, CancellationToken cancellationToken)
    {
        return await _db.Rules
            .Select(r => new GetRulesResponse(r.Id, r.Keyword, r.Who))
            .ToListAsync(cancellationToken);
    }
}
