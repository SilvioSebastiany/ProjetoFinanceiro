using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Boletos.Commands;

public class SaveBoletosCommandHandler : IRequestHandler<SaveBoletosCommand, IEnumerable<SaveBoletosResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public SaveBoletosCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<SaveBoletosResponse>> Handle(SaveBoletosCommand request, CancellationToken cancellationToken)
    {
        var existing = await _db.Boletos
            .Where(b => b.MonthId == request.MonthId)
            .ToListAsync(cancellationToken);

        _db.Boletos.RemoveRange(existing);

        var newBoletos = request.Items.Select(item => new Boleto
        {
            Id = Guid.NewGuid(),
            MonthId = request.MonthId,
            Name = item.Name,
            Amount = item.Amount,
            Who = item.Who,
            CreatedAt = DateTime.UtcNow
        }).ToList();

        _db.Boletos.AddRange(newBoletos);
        await _db.SaveChangesAsync(cancellationToken);

        return newBoletos.Select(b => new SaveBoletosResponse(b.Id, b.Name, b.Amount, b.Who));
    }
}
