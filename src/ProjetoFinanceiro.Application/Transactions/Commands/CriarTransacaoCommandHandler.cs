using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public class CriarTransacaoCommandHandler : IRequestHandler<CriarTransacaoCommand, CriarTransacaoResponse>
{
    private readonly IFinanceiroDbContext _db;

    public CriarTransacaoCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<CriarTransacaoResponse> Handle(CriarTransacaoCommand request, CancellationToken cancellationToken)
    {
        var regra = await _db.Regras
            .FirstOrDefaultAsync(r => request.Descricao.ToLower().Contains(r.PalavraChave.ToLower()), cancellationToken);

        var responsavel = regra?.Responsavel ?? TipoResponsavel.Unknown;

        var transacao = new Transacao(
            request.Data,
            request.Descricao,
            request.Valor,
            responsavel,
            request.Dono,
            request.MesId);

        _db.Transacoes.Add(transacao);
        await _db.SaveChangesAsync(cancellationToken);

        return new CriarTransacaoResponse(
            transacao.Id,
            transacao.Data,
            transacao.Descricao,
            transacao.Valor,
            transacao.Responsavel,
            transacao.Dono,
            transacao.MesId,
            transacao.CriadoEm);
    }
}
