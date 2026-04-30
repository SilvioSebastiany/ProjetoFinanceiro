using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Boletos.Queries;

public class BuscarBoletosPorMesQueryHandler : IRequestHandler<BuscarBoletosPorMesQuery, IEnumerable<BuscarBoletosPorMesResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public BuscarBoletosPorMesQueryHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<BuscarBoletosPorMesResponse>> Handle(BuscarBoletosPorMesQuery request, CancellationToken cancellationToken)
    {
        return await _db.Boletos
            .Where(b => b.MesId == request.MesId)
            .Select(b => new BuscarBoletosPorMesResponse(b.Id, b.Nome, b.Valor, b.Responsavel))
            .ToListAsync(cancellationToken);
    }
}
