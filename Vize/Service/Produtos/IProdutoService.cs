using Vize.API.Model;

namespace Vize.API.Service.Produtos;

public interface IProdutoService
{
    Task<ProdutoResponse> Criar(ProdutoRequest request);
    Task<ProdutoResponse> Editar(long id, ProdutoRequest request);
    Task Delete(long id);
    Task<List<ProdutoResponse>> GetList();
    Task<ProdutoResponse> GetById(long id);
}
