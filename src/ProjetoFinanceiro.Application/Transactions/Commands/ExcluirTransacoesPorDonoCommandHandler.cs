using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public class ExcluirTransacoesPorDonoCommandHandler : IRequestHandler<ExcluirTransacoesPorDonoCommand>
{
    private readonly IFinanceiroDbContext _db;

    public ExcluirTransacoesPorDonoCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task Handle(ExcluirTransacoesPorDonoCommand request, CancellationToken cancellationToken)
    {
        var transacoes = await _db.Transacoes
            .Where(t => t.MesId == request.MesId && t.Dono == request.Dono)
            .ToListAsync(cancellationToken);

        _db.Transacoes.RemoveRange(transacoes);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
