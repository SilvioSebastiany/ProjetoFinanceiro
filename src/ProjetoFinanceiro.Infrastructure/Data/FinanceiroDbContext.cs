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

    public DbSet<Transacao> Transacoes => Set<Transacao>();
    public DbSet<Mes> Meses => Set<Mes>();
    public DbSet<Regra> Regras => Set<Regra>();
    public DbSet<CategoriaBoleto> CategoriasBoleto => Set<CategoriaBoleto>();
    public DbSet<Boleto> Boletos => Set<Boleto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mes>(e =>
        {
            e.ToTable("Meses");
            e.Property(m => m.Id).HasColumnName("Id");
            e.Property(m => m.Rotulo).HasColumnName("Rotulo");
            e.Property(m => m.CriadoEm).HasColumnName("CriadoEm");
        });

        modelBuilder.Entity<Transacao>(e =>
        {
            e.ToTable("Transacoes");
            e.Property(t => t.Id).HasColumnName("Id");
            e.Property(t => t.Data).HasColumnName("Data");
            e.Property(t => t.Descricao).HasColumnName("Descricao");
            e.Property(t => t.Valor).HasColumnName("Valor").HasPrecision(18, 2);
            e.Property(t => t.Responsavel).HasColumnName("Responsavel").HasConversion<int>();
            e.Property(t => t.Dono).HasColumnName("Dono").HasConversion<int>();
            e.Property(t => t.MesId).HasColumnName("MesId");
            e.Property(t => t.CriadoEm).HasColumnName("CriadoEm");
            e.HasOne<Mes>()
                .WithMany(m => m.Transacoes)
                .HasForeignKey(t => t.MesId);
        });

        modelBuilder.Entity<Regra>(e =>
        {
            e.ToTable("Regras");
            e.Property(r => r.Id).HasColumnName("Id");
            e.Property(r => r.PalavraChave).HasColumnName("PalavraChave");
            e.Property(r => r.Responsavel).HasColumnName("Responsavel").HasConversion<int>();
            e.Property(r => r.CriadoEm).HasColumnName("CriadoEm");
        });

        modelBuilder.Entity<CategoriaBoleto>(e =>
        {
            e.ToTable("CategoriasBoleto");
            e.Property(b => b.Id).HasColumnName("Id");
            e.Property(b => b.Nome).HasColumnName("Nome");
            e.Property(b => b.CriadoEm).HasColumnName("CriadoEm");
        });

        modelBuilder.Entity<Boleto>(e =>
        {
            e.ToTable("Boletos");
            e.Property(b => b.Id).HasColumnName("Id");
            e.Property(b => b.MesId).HasColumnName("MesId");
            e.Property(b => b.Nome).HasColumnName("Nome");
            e.Property(b => b.Valor).HasColumnName("Valor").HasPrecision(18, 2);
            e.Property(b => b.Responsavel).HasColumnName("Responsavel").HasConversion<int>();
            e.Property(b => b.CriadoEm).HasColumnName("CriadoEm");
            e.HasOne<Mes>()
                .WithMany()
                .HasForeignKey(b => b.MesId);
        });
    }
}
