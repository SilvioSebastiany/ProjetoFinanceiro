using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Domain.Entities;

public class Month
{
    public Guid Id { get; private set; }
    public string Label { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }

    public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();

    private Month() { } 

    public Month(string label)
    {
        Id = Guid.NewGuid();
        Label = label;
        CreatedAt = DateTime.UtcNow;
    }
}
