using MediatR;

namespace ProjetoFinanceiro.Application.Months.Commands;

public record CreateMonthCommand(string Label) : IRequest<CreateMonthResponse>;

public record CreateMonthResponse(Guid Id, string Label, DateTime CreatedAt);
