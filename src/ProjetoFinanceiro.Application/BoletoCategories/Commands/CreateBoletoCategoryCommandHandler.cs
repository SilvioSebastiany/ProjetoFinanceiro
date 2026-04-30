using MediatR;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.BoletoCategories.Commands;

public class CreateBoletoCategoryCommandHandler : IRequestHandler<CreateBoletoCategoryCommand, CreateBoletoCategoryResponse>
{
    private readonly IFinanceiroDbContext _db;

    public CreateBoletoCategoryCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<CreateBoletoCategoryResponse> Handle(CreateBoletoCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new BoletoCategory
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreatedAt = DateTime.UtcNow
        };

        _db.BoletoCategories.Add(category);
        await _db.SaveChangesAsync(cancellationToken);

        return new CreateBoletoCategoryResponse(category.Id, category.Name);
    }
}
