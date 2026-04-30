using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public class CriarTransacoesEmLoteCommandHandler : IRequestHandler<CriarTransacoesEmLoteCommand, IEnumerable<CriarTransacaoResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public CriarTransacoesEmLoteCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<CriarTransacaoResponse>> Handle(CriarTransacoesEmLoteCommand request, CancellationToken cancellationToken)
    {
        var regras = await _db.Regras.ToListAsync(cancellationToken);

        var transacoes = request.Itens.Select(item =>
        {
            var regra = regras.FirstOrDefault(r => item.Descricao.Contains(r.PalavraChave, StringComparison.OrdinalIgnoreCase));
            var responsavel = regra?.Responsavel ?? TipoResponsavel.Unknown;
            return new Transacao(item.Data, item.Descricao, item.Valor, responsavel, item.Dono, request.MesId);
        }).ToList();

        _db.Transacoes.AddRange(transacoes);
        await _db.SaveChangesAsync(cancellationToken);

        return transacoes.Select(t => new CriarTransacaoResponse(
            t.Id, t.Data, t.Descricao, t.Valor, t.Responsavel, t.Dono, t.MesId, t.CriadoEm));
    }
}
