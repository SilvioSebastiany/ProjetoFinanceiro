using MediatR;

namespace ProjetoFinanceiro.Application.Months.Commands;

public record CriarMesCommand(string Rotulo) : IRequest<CriarMesResponse>;

public record CriarMesResponse(Guid Id, string Rotulo, DateTime CriadoEm);
