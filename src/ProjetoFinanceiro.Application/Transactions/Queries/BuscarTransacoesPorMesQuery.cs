using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Queries;

public record BuscarTransacoesPorMesQuery(Guid MesId) : IRequest<IEnumerable<BuscarTransacoesPorMesResponse>>;

public record BuscarTransacoesPorMesResponse(
    Guid Id,
    DateOnly Data,
    string Descricao,
    decimal Valor,
    TipoResponsavel Responsavel,
    TipoDono Dono,
    DateTime CriadoEm);
