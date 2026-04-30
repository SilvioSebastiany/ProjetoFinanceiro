using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Data;

public interface IFinanceiroDbContext
{
    DbSet<Mes> Meses { get; }
    DbSet<Transacao> Transacoes { get; }
    DbSet<Regra> Regras { get; }
    DbSet<CategoriaBoleto> CategoriasBoleto { get; }
    DbSet<Boleto> Boletos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
