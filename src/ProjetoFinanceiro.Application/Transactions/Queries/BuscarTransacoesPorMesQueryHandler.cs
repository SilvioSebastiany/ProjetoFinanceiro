using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Transactions.Queries;

public class BuscarTransacoesPorMesQueryHandler : IRequestHandler<BuscarTransacoesPorMesQuery, IEnumerable<BuscarTransacoesPorMesResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public BuscarTransacoesPorMesQueryHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<BuscarTransacoesPorMesResponse>> Handle(BuscarTransacoesPorMesQuery request, CancellationToken cancellationToken)
    {
        return await _db.Transacoes
            .Where(t => t.MesId == request.MesId)
            .Select(t => new BuscarTransacoesPorMesResponse(t.Id, t.Data, t.Descricao, t.Valor, t.Responsavel, t.Dono, t.CriadoEm))
            .ToListAsync(cancellationToken);
    }
}
