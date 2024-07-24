using Microsoft.AspNetCore.Mvc;
using Vize.API.Infra;
using Vize.API.Model;
using Vize.API.Service.Produtos;

namespace Vize.API.Controllers;
[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;
    private readonly AppDbContext _appDbContext;

    public ProdutoController(IProdutoService service, AppDbContext appDbContext)
    {
        _service = service;
        _appDbContext = appDbContext;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProdutoResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] ProdutoRequest request)
    {
        try
        {
            var response = await _service.Criar(request);
            await _appDbContext.SaveChangesAsync();
            return Created("Uri", response);
        } catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }   
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(long id, [FromBody] ProdutoRequest request)
    {
        try
        {
            var response = await _service.Editar(id, request);
            await _appDbContext.SaveChangesAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _service.Delete(id);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProdutoResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _service.GetList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProdutoResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await _service.GetById(id));
    }
}
