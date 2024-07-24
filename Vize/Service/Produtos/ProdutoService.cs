using Vize.API.Entities;
using Vize.API.Infra.Repository.Produtos;
using Vize.API.Infra.Repository.Tipo;
using Vize.API.Model;

namespace Vize.API.Service.Produtos;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;
    private readonly ITipoProdutoRepository _tipoProdutoRepository;

    public ProdutoService(IProdutoRepository repository, ITipoProdutoRepository tipoProdutoRepository)
    {
        _repository = repository;
        _tipoProdutoRepository = tipoProdutoRepository;
    }

    public async Task<ProdutoResponse> Criar(ProdutoRequest request)
    {
        if (request == null) throw new Exception("Request não pode estar vazia");
        if (string.IsNullOrWhiteSpace(request.Nome)) throw new Exception("Nome não pode estar vazio");

        var tipoProduto = await _tipoProdutoRepository.GetByChave(request.TipoProdutoEnum);

        if (tipoProduto == null) throw new Exception("Tipo de Produto não encontrado");

        var produto = new Produto()
        {
            Nome = request.Nome,
            PrecoUnitario = request.PrecoUnitario,
            TipoProdutoId = tipoProduto.Id
        };

        await _repository.Insert(produto);

        return new ProdutoResponse()
        {
            Id = produto.Id,
            Nome = produto.Nome,
            ValorUnitario = produto.PrecoUnitario,
            TipoProduto = new TipoProdutoResponse()
            {
                Id = tipoProduto.Id,
                Chave = tipoProduto.Chave,
                Nome = tipoProduto.Nome
            }
        };
    }

    public async Task Delete(long id)
    {
        var produto = await _repository.GetById(id, x => x);

        if (produto is null) throw new Exception("Produto não encontrado");

        await _repository.Delete(produto);
    }

    public async Task<ProdutoResponse> Editar(long id, ProdutoRequest request)
    {
        if (request == null) throw new Exception("Request não pode estar vazia");
        if (string.IsNullOrWhiteSpace(request.Nome)) throw new Exception("Nome não pode estar vazio");

        var produto = await _repository.GetById(id, x => x);

        if (produto is null) throw new Exception("Produto não encontrado");

        var tipoProduto = await _tipoProdutoRepository.GetByChave(request.TipoProdutoEnum);

        if (tipoProduto == null) throw new Exception("Tipo de Produto não encontrado");

        produto.Nome = request.Nome;
        produto.TipoProdutoId = tipoProduto.Id;
        produto.PrecoUnitario = request.PrecoUnitario;

        await _repository.Update(produto);

        return new ProdutoResponse()
        {
            Id = produto.Id,
            Nome = produto.Nome,
            ValorUnitario = produto.PrecoUnitario,
            TipoProduto = new TipoProdutoResponse()
            {
                Id = tipoProduto.Id,
                Chave = tipoProduto.Chave,
                Nome = tipoProduto.Nome
            }
        };
    }

    public async Task<ProdutoResponse> GetById(long id)
    {
        return await _repository.GetById(id, x => new ProdutoResponse()
        {
            Id = x.Id,
            Nome = x.Nome,
            ValorUnitario = x.PrecoUnitario,
            TipoProduto = new TipoProdutoResponse()
            {
                Id = x.TipoProduto.Id,
                Chave = x.TipoProduto.Chave,
                Nome = x.TipoProduto.Nome
            }
        });
    }

    public async Task<List<ProdutoResponse>> GetList()
    {
        return await _repository.GetList(x => new ProdutoResponse()
        {
            Id = x.Id,
            Nome = x.Nome,
            ValorUnitario = x.PrecoUnitario,
            TipoProduto = new TipoProdutoResponse()
            {
                Id = x.TipoProduto.Id,
                Chave = x.TipoProduto.Chave,
                Nome = x.TipoProduto.Nome
            }
        });
    }
}
