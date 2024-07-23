using Vize.API.Entities;

namespace Vize.API.Infra.Repository.Produtos;

public interface IProdutoRepository
{
    Task<Produto> GetById(long id);
    Task<List<Produto>> GetList();
    Task Insert(Produto produto);
    Task Update(Produto produto);
    Task Delete(Produto produto);
}
