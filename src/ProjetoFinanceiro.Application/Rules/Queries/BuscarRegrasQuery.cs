using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Rules.Queries;

public record BuscarRegrasQuery : IRequest<IEnumerable<BuscarRegrasResponse>>;

public record BuscarRegrasResponse(Guid Id, string PalavraChave, TipoResponsavel Responsavel);
