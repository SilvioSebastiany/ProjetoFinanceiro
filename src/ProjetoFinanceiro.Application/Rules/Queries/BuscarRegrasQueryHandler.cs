using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Rules.Queries;

public class BuscarRegrasQueryHandler : IRequestHandler<BuscarRegrasQuery, IEnumerable<BuscarRegrasResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public BuscarRegrasQueryHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<BuscarRegrasResponse>> Handle(BuscarRegrasQuery request, CancellationToken cancellationToken)
    {
        return await _db.Regras
            .Select(r => new BuscarRegrasResponse(r.Id, r.PalavraChave, r.Responsavel))
            .ToListAsync(cancellationToken);
    }
}
