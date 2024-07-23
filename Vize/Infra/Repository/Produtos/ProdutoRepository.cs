using Microsoft.EntityFrameworkCore;
using Vize.API.Entities;

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
            _appDbContext.Set<Produto>().Remove(produto);
        });
    }

    public async Task<Produto> GetById(long id)
    {
        return await _appDbContext.Set<Produto>().Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Produto>> GetList()
    {
        return await _appDbContext.Set<Produto>().ToListAsync();
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
            _appDbContext.Set<Produto>().Update(produto);
        });
    }
}
