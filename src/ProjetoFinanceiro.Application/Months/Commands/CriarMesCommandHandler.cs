using MediatR;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Months.Commands;

public class CriarMesCommandHandler : IRequestHandler<CriarMesCommand, CriarMesResponse>
{
    private readonly IFinanceiroDbContext _db;

    public CriarMesCommandHandler(IFinanceiroDbContext db)
    {
        _db = db;
    }

    public async Task<CriarMesResponse> Handle(CriarMesCommand request, CancellationToken cancellationToken)
    {
        var mes = new Mes(request.Rotulo);

        _db.Meses.Add(mes);
        await _db.SaveChangesAsync(cancellationToken);

        return new CriarMesResponse(mes.Id, mes.Rotulo, mes.CriadoEm);
    }
}
