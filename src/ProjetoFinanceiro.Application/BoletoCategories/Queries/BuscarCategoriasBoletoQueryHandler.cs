using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.BoletoCategories.Queries;

public class BuscarCategoriasBoletoQueryHandler : IRequestHandler<BuscarCategoriasBoletoQuery, IEnumerable<BuscarCategoriasBoletoResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public BuscarCategoriasBoletoQueryHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<BuscarCategoriasBoletoResponse>> Handle(BuscarCategoriasBoletoQuery request, CancellationToken cancellationToken)
    {
        return await _db.CategoriasBoleto
            .Select(b => new BuscarCategoriasBoletoResponse(b.Id, b.Nome))
            .ToListAsync(cancellationToken);
    }
}
