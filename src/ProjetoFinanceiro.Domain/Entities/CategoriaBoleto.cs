namespace ProjetoFinanceiro.Domain.Entities;

public class CategoriaBoleto
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Nome { get; set; } = string.Empty;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
