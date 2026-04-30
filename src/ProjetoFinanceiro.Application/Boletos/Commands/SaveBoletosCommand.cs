using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Boletos.Commands;

public record SaveBoletosCommand(Guid MonthId, List<SaveBoletoItem> Items) : IRequest<IEnumerable<SaveBoletosResponse>>;

public record SaveBoletoItem(string Name, decimal Amount, WhoType Who);

public record SaveBoletosResponse(Guid Id, string Name, decimal Amount, WhoType Who);
