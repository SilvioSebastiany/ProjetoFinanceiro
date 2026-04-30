using MediatR;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.BoletoCategories.Commands;

public class CriarCategoriaBoletoCommandHandler : IRequestHandler<CriarCategoriaBoletoCommand, CriarCategoriaBoletoResponse>
{
    private readonly IFinanceiroDbContext _db;

    public CriarCategoriaBoletoCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<CriarCategoriaBoletoResponse> Handle(CriarCategoriaBoletoCommand request, CancellationToken cancellationToken)
    {
        var categoria = new CategoriaBoleto
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            CriadoEm = DateTime.UtcNow
        };

        _db.CategoriasBoleto.Add(categoria);
        await _db.SaveChangesAsync(cancellationToken);

        return new CriarCategoriaBoletoResponse(categoria.Id, categoria.Nome);
    }
}
