using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.BoletoCategories.Queries;

public class GetBoletoCategoriesQueryHandler : IRequestHandler<GetBoletoCategoriesQuery, IEnumerable<GetBoletoCategoriesResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public GetBoletoCategoriesQueryHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetBoletoCategoriesResponse>> Handle(GetBoletoCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _db.BoletoCategories
            .Select(b => new GetBoletoCategoriesResponse(b.Id, b.Name))
            .ToListAsync(cancellationToken);
    }
}
