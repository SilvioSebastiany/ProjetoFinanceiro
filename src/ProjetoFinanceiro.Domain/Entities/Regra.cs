namespace ProjetoFinanceiro.Domain.Entities;

public class Regra
{
    public Guid Id { get; set; }
    public string PalavraChave { get; set; } = string.Empty;
    public TipoResponsavel Responsavel { get; set; }
    public DateTime CriadoEm { get; set; }
}
