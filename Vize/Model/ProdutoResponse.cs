using Vize.API.Entities;

namespace Vize.API.Model;

public class ProdutoResponse
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public decimal ValorUnitario { get; set; }
    public TipoProdutoResponse TipoProduto { get; set; }
}

public class TipoProdutoResponse
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public TipoProdutoEnum Chave { get; set; }
}
