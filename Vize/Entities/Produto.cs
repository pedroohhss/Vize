using System.ComponentModel.DataAnnotations.Schema;

namespace Vize.API.Entities;

public class Produto
{
    public long Id { get; set; }
    public string Nome { get; set; } = null!;
    public decimal PrecoUnitario { get; set; }
    public long TipoProdutoId { get; set; }
    [ForeignKey(nameof(TipoProdutoId))]
    public TipoProduto TipoProduto { get; set; } = null!;
}
