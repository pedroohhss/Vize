using System.Linq.Expressions;
using Vize.API.Entities;
using Vize.API.Model;

namespace Vize.API.Infra.Repository.Produtos;

public interface IProdutoRepository
{
    Task<TDTO> GetById<TDTO>(long id, Expression<Func<Produto, TDTO>> expression);
    Task<List<TDTO>> GetList<TDTO>(Expression<Func<Produto, TDTO>> expression);
    Task Insert(Produto produto);
    Task Update(Produto produto);
    Task Delete(Produto produto);
    Task<List<ProdutoDashboardResponse>> GetDashboard();
}
