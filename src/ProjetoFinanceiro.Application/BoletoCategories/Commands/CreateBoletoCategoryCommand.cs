using MediatR;

namespace ProjetoFinanceiro.Application.BoletoCategories.Commands;

public record CreateBoletoCategoryCommand(string Name) : IRequest<CreateBoletoCategoryResponse>;

public record CreateBoletoCategoryResponse(Guid Id, string Name);
