namespace ProjetoFinanceiro.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public DateOnly Date { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public WhoType Who { get; private set; }
    public Guid MonthId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Transaction(
        DateOnly date,
        string description,
        decimal amount,
        WhoType who,
        Guid monthId)
    {
        Id = Guid.NewGuid();
        Date = date;
        Description = description;
        Amount = amount;
        Who = who;
        MonthId = monthId;
        CreatedAt = DateTime.UtcNow;
    }
}
