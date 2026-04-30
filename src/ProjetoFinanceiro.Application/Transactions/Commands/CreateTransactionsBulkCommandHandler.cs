using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public class CreateTransactionsBulkCommandHandler : IRequestHandler<CreateTransactionsBulkCommand, IEnumerable<CreateTransactionResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public CreateTransactionsBulkCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<CreateTransactionResponse>> Handle(CreateTransactionsBulkCommand request, CancellationToken cancellationToken)
    {
        var rules = await _db.Rules.ToListAsync(cancellationToken);

        var transactions = request.Items.Select(item =>
        {
            var rule = rules.FirstOrDefault(r => item.Description.Contains(r.Keyword, StringComparison.OrdinalIgnoreCase));
            var who = rule?.Who ?? WhoType.Unknown;
            return new Transaction(item.Date, item.Description, item.Amount, who, item.CardOwner, request.MonthId);
        }).ToList();

        _db.Transactions.AddRange(transactions);
        await _db.SaveChangesAsync(cancellationToken);

        return transactions.Select(t => new CreateTransactionResponse(
            t.Id, t.Date, t.Description, t.Amount, t.Who, t.CardOwner, t.MonthId, t.CreatedAt));
    }
}
