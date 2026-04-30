using MediatR;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Rules.Commands;

public class CriarRegraCommandHandler : IRequestHandler<CriarRegraCommand, CriarRegraResponse>
{
    private readonly IFinanceiroDbContext _db;

    public CriarRegraCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<CriarRegraResponse> Handle(CriarRegraCommand request, CancellationToken cancellationToken)
    {
        var regra = new Regra
        {
            Id = Guid.NewGuid(),
            PalavraChave = request.PalavraChave,
            Responsavel = request.Responsavel,
            CriadoEm = DateTime.UtcNow
        };

        _db.Regras.Add(regra);
        await _db.SaveChangesAsync(cancellationToken);

        return new CriarRegraResponse(regra.Id, regra.PalavraChave, regra.Responsavel);
    }
}
