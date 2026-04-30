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
        modelBuilder.Entity<Month>(e =>
        {
            e.ToTable("Meses");
            e.Property(m => m.Id).HasColumnName("Id");
            e.Property(m => m.Label).HasColumnName("Rotulo");
            e.Property(m => m.CreatedAt).HasColumnName("CriadoEm");
        });

        modelBuilder.Entity<Transaction>(e =>
        {
            e.ToTable("Transacoes");
            e.Property(t => t.Id).HasColumnName("Id");
            e.Property(t => t.Date).HasColumnName("Data");
            e.Property(t => t.Description).HasColumnName("Descricao");
            e.Property(t => t.Amount).HasColumnName("Valor").HasPrecision(18, 2);
            e.Property(t => t.Who).HasColumnName("Responsavel").HasConversion<int>();
            e.Property(t => t.MonthId).HasColumnName("MesId");
            e.Property(t => t.CreatedAt).HasColumnName("CriadoEm");
            e.HasOne<Month>()
                .WithMany(m => m.Transactions)
                .HasForeignKey(t => t.MonthId);
        });

        modelBuilder.Entity<Rule>(e =>
        {
            e.ToTable("Regras");
            e.Property(r => r.Id).HasColumnName("Id");
            e.Property(r => r.Keyword).HasColumnName("PalavraChave");
            e.Property(r => r.Who).HasColumnName("Responsavel").HasConversion<int>();
            e.Property(r => r.CreatedAt).HasColumnName("CriadoEm");
        });

        modelBuilder.Entity<BoletoCategory>(e =>
        {
            e.ToTable("CategoriasBoleto");
            e.Property(b => b.Id).HasColumnName("Id");
            e.Property(b => b.Name).HasColumnName("Nome");
            e.Property(b => b.CreatedAt).HasColumnName("CriadoEm");
        });
    }
}
