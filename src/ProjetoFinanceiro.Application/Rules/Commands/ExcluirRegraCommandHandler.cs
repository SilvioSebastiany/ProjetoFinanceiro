using MediatR;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Rules.Commands;

public class ExcluirRegraCommandHandler : IRequestHandler<ExcluirRegraCommand, bool>
{
    private readonly IFinanceiroDbContext _db;

    public ExcluirRegraCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(ExcluirRegraCommand request, CancellationToken cancellationToken)
    {
        var regra = await _db.Regras.FindAsync([request.Id], cancellationToken);
        if (regra is null) return false;

        _db.Regras.Remove(regra);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
