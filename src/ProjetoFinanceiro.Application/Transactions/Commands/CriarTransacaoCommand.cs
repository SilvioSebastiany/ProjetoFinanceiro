using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Transactions.Commands;

public record CriarTransacaoCommand(
    DateOnly Data,
    string Descricao,
    decimal Valor,
    TipoDono Dono,
    Guid MesId) : IRequest<CriarTransacaoResponse>;

public record CriarTransacaoResponse(
    Guid Id,
    DateOnly Data,
    string Descricao,
    decimal Valor,
    TipoResponsavel Responsavel,
    TipoDono Dono,
    Guid MesId,
    DateTime CriadoEm);
