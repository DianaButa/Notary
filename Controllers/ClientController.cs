using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notary.Database;
using Notary.DTO;
using Notary.Models;
using Notary.Service;
using System.Threading.Tasks;

namespace Notary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClientController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly IClientService _clientService;

    public ClientController(ApplicationDbContext context, IClientService clientService)
    {
      _context = context;
      _clientService = clientService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClient()
    {
      var files = await _clientService.GetAllAsync();
      if (files == null || !files.Any())
      {
        return NotFound();
      }
      return Ok(files);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDTO>> GetClient(int id)
    {
      var clientDTO = await _clientService.GetClientById(id);
      if (clientDTO == null)
      {
        return NotFound();
      }
      return clientDTO;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddClient(ClientDTO clientDto)
    {
      try
      {
        await _clientService.AddProduct(clientDto);
        return Ok("Product added successfully.");
      }
      catch (System.Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding product: {ex.Message}");
      }
    }

    [HttpDelete("{id}")]
    public async Task DeletebyId(int id)
    {
      await _clientService.DeleteProduct(id);
    }


    [HttpPut("edit")]
    public async Task<IActionResult> Edit(int id, [FromBody] ClientDTO clientDto)
    {
      try
      {
        clientDto.Id = id;
        await _clientService.EditAsync(clientDto);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
  }

