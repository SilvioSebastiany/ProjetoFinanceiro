using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, CreateTransactionResponse>
{
    private readonly IFinanceiroDbContext _db;

    public CreateTransactionCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<CreateTransactionResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var rule = await _db.Rules
            .FirstOrDefaultAsync(r => request.Description.ToLower().Contains(r.Keyword.ToLower()), cancellationToken);

        var who = rule?.Who ?? WhoType.Unknown;

        var transaction = new Transaction(
            request.Date,
            request.Description,
            request.Amount,
            who,
            request.CardOwner,
            request.MonthId);

        _db.Transactions.Add(transaction);
        await _db.SaveChangesAsync(cancellationToken);

        return new CreateTransactionResponse(
            transaction.Id,
            transaction.Date,
            transaction.Description,
            transaction.Amount,
            transaction.Who,
            transaction.CardOwner,
            transaction.MonthId,
            transaction.CreatedAt);
    }
}
