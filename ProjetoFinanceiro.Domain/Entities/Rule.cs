namespace ProjetoFinanceiro.Domain.Entities;

public class Rule
{
    public Guid Id { get; set; }
    public string Keyword { get; set; } = string.Empty;
    public WhoType Who { get; set; }
    public DateTime CreatedAt { get; set; }
}
