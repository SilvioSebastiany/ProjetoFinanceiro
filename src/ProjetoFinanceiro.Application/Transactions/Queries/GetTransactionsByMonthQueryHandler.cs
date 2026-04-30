using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Transactions.Queries;

public class GetTransactionsByMonthQueryHandler : IRequestHandler<GetTransactionsByMonthQuery, IEnumerable<GetTransactionsByMonthResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public GetTransactionsByMonthQueryHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetTransactionsByMonthResponse>> Handle(GetTransactionsByMonthQuery request, CancellationToken cancellationToken)
    {
        return await _db.Transactions
            .Where(t => t.MonthId == request.MonthId)
            .Select(t => new GetTransactionsByMonthResponse(t.Id, t.Date, t.Description, t.Amount, t.Who, t.CardOwner, t.CreatedAt))
            .ToListAsync(cancellationToken);
    }
}
