using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Application.Data;
using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Infrastructure.Data;

public class FinanceiroDbContext : DbContext, IFinanceiroDbContext
{
    public FinanceiroDbContext(DbContextOptions<FinanceiroDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Month> Months => Set<Month>();
    public DbSet<Rule> Rules => Set<Rule>();
    public DbSet<BoletoCategory> BoletoCategories => Set<BoletoCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasOne<Month>()
            .WithMany(m => m.Transactions)
            .HasForeignKey(t => t.MonthId);

        modelBuilder.Entity<Rule>()
            .Property(r => r.Who)
            .HasConversion<int>();

        modelBuilder.Entity<Transaction>()
            .Property(t => t.Who)
            .HasConversion<int>();
    }
}
