namespace ProjetoFinanceiro.Domain.Entities;

public class Boleto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid MonthId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public WhoType Who { get; set; } = WhoType.Shared;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
