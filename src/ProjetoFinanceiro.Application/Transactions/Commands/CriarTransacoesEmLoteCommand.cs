using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public record CriarTransacoesEmLoteCommand(
    Guid MesId,
    List<CriarTransacaoEmLoteItem> Itens) : IRequest<IEnumerable<CriarTransacaoResponse>>;

public record CriarTransacaoEmLoteItem(
    DateOnly Data,
    string Descricao,
    decimal Valor,
    TipoDono Dono);
