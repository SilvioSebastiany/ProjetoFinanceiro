using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Boletos.Queries;

public class GetBoletosByMonthQueryHandler : IRequestHandler<GetBoletosByMonthQuery, IEnumerable<GetBoletosByMonthResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public GetBoletosByMonthQueryHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetBoletosByMonthResponse>> Handle(GetBoletosByMonthQuery request, CancellationToken cancellationToken)
    {
        return await _db.Boletos
            .Where(b => b.MonthId == request.MonthId)
            .Select(b => new GetBoletosByMonthResponse(b.Id, b.Name, b.Amount, b.Who))
            .ToListAsync(cancellationToken);
    }
}
