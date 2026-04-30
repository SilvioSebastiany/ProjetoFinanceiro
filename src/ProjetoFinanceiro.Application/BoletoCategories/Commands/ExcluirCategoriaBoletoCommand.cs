using MediatR;

namespace ProjetoFinanceiro.Application.BoletoCategories.Commands;

public record ExcluirCategoriaBoletoCommand(Guid Id) : IRequest<bool>;
