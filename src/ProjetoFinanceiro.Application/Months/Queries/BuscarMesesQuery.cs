using MediatR;

namespace ProjetoFinanceiro.Application.Months.Queries;

public record BuscarMesesQuery : IRequest<IEnumerable<BuscarMesesResponse>>;

public record BuscarMesesResponse(Guid Id, string Rotulo, DateTime CriadoEm);
