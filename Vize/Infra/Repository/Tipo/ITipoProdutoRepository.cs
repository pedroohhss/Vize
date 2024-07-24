using System.Linq.Expressions;
using Vize.API.Entities;

namespace Vize.API.Infra.Repository.Tipo;

public interface ITipoProdutoRepository
{
    Task<TipoProduto> GetByChave(TipoProdutoEnum chave);
    Task<List<TDTO>> GetList<TDTO>(Expression<Func<TipoProduto, TDTO>> expression);
}
