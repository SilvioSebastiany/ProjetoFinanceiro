namespace ProjetoFinanceiro.Domain.Entities;

public class BoletoCategory
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // Ex: Água, Luz, Internet, Mercado
    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
