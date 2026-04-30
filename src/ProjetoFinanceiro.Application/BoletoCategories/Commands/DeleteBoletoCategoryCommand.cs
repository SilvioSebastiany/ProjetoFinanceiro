using MediatR;

namespace ProjetoFinanceiro.Application.BoletoCategories.Commands;

public record DeleteBoletoCategoryCommand(Guid Id) : IRequest<bool>;
