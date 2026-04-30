using MediatR;

namespace ProjetoFinanceiro.Application.BoletoCategories.Commands;

public record CriarCategoriaBoletoCommand(string Nome) : IRequest<CriarCategoriaBoletoResponse>;

public record CriarCategoriaBoletoResponse(Guid Id, string Nome);
