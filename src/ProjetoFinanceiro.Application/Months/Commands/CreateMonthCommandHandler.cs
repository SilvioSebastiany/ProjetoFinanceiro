using MediatR;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Months.Commands;

public class CreateMonthCommandHandler : IRequestHandler<CreateMonthCommand, CreateMonthResponse>
{
    private readonly IFinanceiroDbContext _db;

    public CreateMonthCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<CreateMonthResponse> Handle(CreateMonthCommand request, CancellationToken cancellationToken)
    {
        var month = new Month(request.Label);

        _db.Months.Add(month);
        await _db.SaveChangesAsync(cancellationToken);

        return new CreateMonthResponse(month.Id, month.Label, month.CreatedAt);
    }
}
