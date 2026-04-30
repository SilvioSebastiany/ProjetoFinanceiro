using MediatR;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.BoletoCategories.Commands;

public class ExcluirCategoriaBoletoCommandHandler : IRequestHandler<ExcluirCategoriaBoletoCommand, bool>
{
    private readonly IFinanceiroDbContext _db;

    public ExcluirCategoriaBoletoCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(ExcluirCategoriaBoletoCommand request, CancellationToken cancellationToken)
    {
        var categoria = await _db.CategoriasBoleto.FindAsync([request.Id], cancellationToken);
        if (categoria is null) return false;

        _db.CategoriasBoleto.Remove(categoria);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
