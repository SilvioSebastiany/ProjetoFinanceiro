namespace ProjetoFinanceiro.Application.Transactions;

public class CreateTransactionRequest
{
    public DateOnly Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public Guid MonthId { get; set; }
}
