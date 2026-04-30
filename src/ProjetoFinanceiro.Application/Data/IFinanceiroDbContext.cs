using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Application.Data;

public interface IFinanceiroDbContext
{
    DbSet<Month> Months { get; }
    DbSet<Transaction> Transactions { get; }
    DbSet<Rule> Rules { get; }
    DbSet<BoletoCategory> BoletoCategories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
