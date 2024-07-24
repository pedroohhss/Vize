using Vize.API.Model;

namespace Vize.API.Service.TipoProdutos;

public interface ITipoProdutoService
{
    Task<List<TipoProdutoResponse>> GetList();
}
