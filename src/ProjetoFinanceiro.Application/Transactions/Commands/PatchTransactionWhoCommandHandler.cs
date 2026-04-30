using MediatR;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public class PatchTransactionWhoCommandHandler : IRequestHandler<PatchTransactionWhoCommand, bool>
{
    private readonly IFinanceiroDbContext _db;

    public PatchTransactionWhoCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(PatchTransactionWhoCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _db.Transactions.FindAsync([request.Id], cancellationToken);
        if (transaction is null) return false;

        transaction.Who = request.Who;
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
