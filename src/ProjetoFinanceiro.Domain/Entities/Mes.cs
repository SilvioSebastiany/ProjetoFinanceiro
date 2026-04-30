using ProjetoFinanceiro.Domain.Entities;

namespace ProjetoFinanceiro.Domain.Entities;

public class Mes
{
    public Guid Id { get; private set; }
    public string Rotulo { get; private set; } = null!;
    public DateTime CriadoEm { get; private set; }

    public ICollection<Transacao> Transacoes { get; private set; } = new List<Transacao>();

    private Mes() { }

    public Mes(string rotulo)
    {
        Id = Guid.NewGuid();
        Rotulo = rotulo;
        CriadoEm = DateTime.UtcNow;
    }
}
