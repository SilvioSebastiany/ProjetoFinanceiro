using MediatR;
using ProjetoFinanceiro.Application.Data;

namespace ProjetoFinanceiro.Application.BoletoCategories.Commands;

public class DeleteBoletoCategoryCommandHandler : IRequestHandler<DeleteBoletoCategoryCommand, bool>
{
    private readonly IFinanceiroDbContext _db;

    public DeleteBoletoCategoryCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(DeleteBoletoCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _db.BoletoCategories.FindAsync([request.Id], cancellationToken);
        if (category is null) return false;

        _db.BoletoCategories.Remove(category);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
