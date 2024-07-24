using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vize.API.Infra;
using Vize.API.Model;
using Vize.API.Service.TipoProdutos;

namespace Vize.API.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class TipoProdutoController : ControllerBase
{
    private readonly ITipoProdutoService _service;
    private readonly AppDbContext _appDbContext;

    public TipoProdutoController(ITipoProdutoService service, AppDbContext appDbContext)
    {
        _service = service;
        _appDbContext = appDbContext;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TipoProdutoResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _service.GetList());
    }
}
