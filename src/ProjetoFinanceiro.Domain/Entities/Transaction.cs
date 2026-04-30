namespace ProjetoFinanceiro.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public DateOnly Date { get; private set; }
    public string Description { get; private set; } = null!;
    public decimal Amount { get; private set; }
    public WhoType Who { get; set; }
    public CardOwnerType CardOwner { get; private set; }
    public Guid MonthId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Transaction() { }

    public Transaction(
        DateOnly date,
        string description,
        decimal amount,
        WhoType who,
        CardOwnerType cardOwner,
        Guid monthId)
    {
        Id = Guid.NewGuid();
        Date = date;
        Description = description;
        Amount = amount;
        Who = who;
        CardOwner = cardOwner;
        MonthId = monthId;
        CreatedAt = DateTime.UtcNow;
    }
}
