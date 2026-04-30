using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Months.Queries;

public class BuscarMesesQueryHandler : IRequestHandler<BuscarMesesQuery, IEnumerable<BuscarMesesResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public BuscarMesesQueryHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<BuscarMesesResponse>> Handle(BuscarMesesQuery request, CancellationToken cancellationToken)
    {
        return await _db.Meses
            .Select(m => new BuscarMesesResponse(m.Id, m.Rotulo, m.CriadoEm))
            .ToListAsync(cancellationToken);
    }
}
