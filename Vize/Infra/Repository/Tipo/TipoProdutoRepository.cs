using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vize.API.Entities;

namespace Vize.API.Infra.Repository.Tipo;

public class TipoProdutoRepository : ITipoProdutoRepository
{
    private readonly AppDbContext _appDbContext;

    public TipoProdutoRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<TipoProduto> GetByChave(TipoProdutoEnum chave)
    {
        return await _appDbContext.TipoProduto.Where(x => x.Chave == chave).SingleOrDefaultAsync();
    }

    public async Task<List<TDTO>> GetList<TDTO>(Expression<Func<TipoProduto, TDTO>> expression)
    {
        return await _appDbContext.TipoProduto.AsNoTracking().Select(expression).ToListAsync();
    }
}
