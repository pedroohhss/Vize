using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vize.API.Entities;
using Vize.API.Model;

namespace Vize.API.Infra.Repository.Produtos;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _appDbContext;

    public ProdutoRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Delete(Produto produto)
    {
        await Task.Run(delegate
        {
            _appDbContext.Entry(produto).State = EntityState.Deleted;
        });
    }

    public async Task<TDTO> GetById<TDTO>(long id, Expression<Func<Produto, TDTO>> expression)
    {
        return await _appDbContext.Produto.AsNoTracking().Where(x => x.Id == id).Include(x => x.TipoProduto).Select(expression).FirstOrDefaultAsync();
    }

    public async Task<List<ProdutoDashboardResponse>> GetDashboard()
    {
        return await _appDbContext.Produto.GroupBy(x => x.TipoProdutoId).Select(x => new ProdutoDashboardResponse()
        {
            Tipo = x.Select(p => p.TipoProduto.Nome).First(),
            Quantidade = x.Count(),
            PrecoMedio = x.Average(p => p.PrecoUnitario)
        }).ToListAsync();
    }

    public async Task<List<TDTO>> GetList<TDTO>(Expression<Func<Produto, TDTO>> expression)
    {
        return await _appDbContext.Produto.AsNoTracking().Include(x => x.TipoProduto).Select(expression).ToListAsync();
    }

    public async Task Insert(Produto produto)
    {
        await Task.Run(delegate
        {
            _appDbContext.Set<Produto>().Add(produto);
        });
    }

    public async Task Update(Produto produto)
    {
        await Task.Run(delegate
        {
            _appDbContext.Entry(produto).State = EntityState.Modified;
        });
    }
}
