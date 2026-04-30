using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Boletos.Queries;

public record BuscarBoletosPorMesQuery(Guid MesId) : IRequest<IEnumerable<BuscarBoletosPorMesResponse>>;

public record BuscarBoletosPorMesResponse(Guid Id, string Nome, decimal Valor, TipoResponsavel Responsavel);
