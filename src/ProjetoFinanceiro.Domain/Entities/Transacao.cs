namespace ProjetoFinanceiro.Domain.Entities;

public class Transacao
{
    public Guid Id { get; private set; }
    public DateOnly Data { get; private set; }
    public string Descricao { get; private set; } = null!;
    public decimal Valor { get; private set; }
    public TipoResponsavel Responsavel { get; set; }
    public TipoDono Dono { get; private set; }
    public Guid MesId { get; private set; }
    public DateTime CriadoEm { get; private set; }

    private Transacao() { }

    public Transacao(
        DateOnly data,
        string descricao,
        decimal valor,
        TipoResponsavel responsavel,
        TipoDono dono,
        Guid mesId)
    {
        Id = Guid.NewGuid();
        Data = data;
        Descricao = descricao;
        Valor = valor;
        Responsavel = responsavel;
        Dono = dono;
        MesId = mesId;
        CriadoEm = DateTime.UtcNow;
    }
}
