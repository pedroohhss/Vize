using Vize.API.Infra.Repository.Tipo;
using Vize.API.Model;

namespace Vize.API.Service.TipoProdutos;

public class TipoProdutoService : ITipoProdutoService
{
    private readonly ITipoProdutoRepository _repository;

    public TipoProdutoService(ITipoProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TipoProdutoResponse>> GetList()
    {
        return await _repository.GetList(x => new TipoProdutoResponse()
        {
            Id = x.Id,
            Chave = x.Chave,
            Nome = x.Nome
        });
    }
}
