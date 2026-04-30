using MediatR;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Rules.Commands;

public record CriarRegraCommand(string PalavraChave, TipoResponsavel Responsavel) : IRequest<CriarRegraResponse>;

public record CriarRegraResponse(Guid Id, string PalavraChave, TipoResponsavel Responsavel);
