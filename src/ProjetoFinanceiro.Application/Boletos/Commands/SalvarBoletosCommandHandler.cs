using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Boletos.Commands;

public class SalvarBoletosCommandHandler : IRequestHandler<SalvarBoletosCommand, IEnumerable<SalvarBoletosResponse>>
{
    private readonly IFinanceiroDbContext _db;

    public SalvarBoletosCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<SalvarBoletosResponse>> Handle(SalvarBoletosCommand request, CancellationToken cancellationToken)
    {
        var existentes = await _db.Boletos
            .Where(b => b.MesId == request.MesId)
            .ToListAsync(cancellationToken);

        _db.Boletos.RemoveRange(existentes);

        var novosBoletos = request.Itens.Select(item => new Boleto
        {
            Id = Guid.NewGuid(),
            MesId = request.MesId,
            Nome = item.Nome,
            Valor = item.Valor,
            Responsavel = item.Responsavel,
            CriadoEm = DateTime.UtcNow
        }).ToList();

        _db.Boletos.AddRange(novosBoletos);
        await _db.SaveChangesAsync(cancellationToken);

        return novosBoletos.Select(b => new SalvarBoletosResponse(b.Id, b.Nome, b.Valor, b.Responsavel));
    }
}
