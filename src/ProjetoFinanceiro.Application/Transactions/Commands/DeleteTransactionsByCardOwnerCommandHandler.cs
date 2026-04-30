using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public class DeleteTransactionsByCardOwnerCommandHandler : IRequestHandler<DeleteTransactionsByCardOwnerCommand>
{
    private readonly IFinanceiroDbContext _db;

    public DeleteTransactionsByCardOwnerCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task Handle(DeleteTransactionsByCardOwnerCommand request, CancellationToken cancellationToken)
    {
        var transactions = await _db.Transactions
            .Where(t => t.MonthId == request.MonthId && t.CardOwner == request.CardOwner)
            .ToListAsync(cancellationToken);

        _db.Transactions.RemoveRange(transactions);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
