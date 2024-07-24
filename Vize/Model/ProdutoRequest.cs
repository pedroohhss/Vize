using Vize.API.Entities;

namespace Vize.API.Model;

public class ProdutoRequest
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoUnitario { get; set; }
    public TipoProdutoEnum TipoProdutoEnum { get; set; }
}
