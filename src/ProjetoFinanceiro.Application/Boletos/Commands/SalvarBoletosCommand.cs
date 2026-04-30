using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Boletos.Commands;

public record SalvarBoletosCommand(Guid MesId, List<SalvarBoletoItem> Itens) : IRequest<IEnumerable<SalvarBoletosResponse>>;

public record SalvarBoletoItem(string Nome, decimal Valor, TipoResponsavel Responsavel);

public record SalvarBoletosResponse(Guid Id, string Nome, decimal Valor, TipoResponsavel Responsavel);
