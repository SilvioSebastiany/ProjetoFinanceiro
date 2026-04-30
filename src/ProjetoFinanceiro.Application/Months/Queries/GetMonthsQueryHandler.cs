using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Months.Queries;

public class GetMonthsQueryHandler : IRequestHandler<GetMonthsQuery, IEnumerable<GetMonthsResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public GetMonthsQueryHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetMonthsResponse>> Handle(GetMonthsQuery request, CancellationToken cancellationToken)
    {
        return await _db.Months
            .Select(m => new GetMonthsResponse(m.Id, m.Label, m.CreatedAt))
            .ToListAsync(cancellationToken);
    }
}
