using MediatR;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public class AtualizarResponsavelTransacaoCommandHandler : IRequestHandler<AtualizarResponsavelTransacaoCommand, bool>
{
    private readonly IFinanceiroDbContext _db;

    public AtualizarResponsavelTransacaoCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(AtualizarResponsavelTransacaoCommand request, CancellationToken cancellationToken)
    {
        var transacao = await _db.Transacoes.FindAsync([request.Id], cancellationToken);
        if (transacao is null) return false;

        transacao.Responsavel = request.Responsavel;
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
