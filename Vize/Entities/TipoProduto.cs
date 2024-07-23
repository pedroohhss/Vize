using System.ComponentModel.DataAnnotations;

namespace Vize.API.Entities;

public class TipoProduto
{
    public long Id { get; set; }
    public string Nome { get; set; } = null!;
    public TipoProdutoEnum Chave { get; set; }
}

public enum TipoProdutoEnum
{
    [Display(Name = "Material")]
    Material = 1,
    [Display(Name = "Serviço")]
    Servico = 2
}
