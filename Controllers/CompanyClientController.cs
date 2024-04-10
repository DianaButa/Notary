using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notary.Database;
using Notary.DTO;
using Notary.Service;

namespace Notary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CompanyClientController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly ICompanyClientService _companyclientService;

    public CompanyClientController(ApplicationDbContext context, ICompanyClientService companyclientService)
    {
      _context = context;
      _companyclientService = companyclientService;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyClientDTO>> GetCompanyClient(int id)
    {
      var companyclientDTO = await _companyclientService.GetCompanyClientById(id);
      if (companyclientDTO == null)
      {
        return NotFound();
      }
      return companyclientDTO;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddCompanyClient(CompanyClientDTO companyclientDto)
    {
      try
      {
        await _companyclientService.AddCompanyClient(companyclientDto);
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
      await _companyclientService.DeleteCompanyClient(id);
    }


    [HttpPut("edit")]
    public async Task<IActionResult> Edit(int id, [FromBody] CompanyClientDTO companyclientDto)
    {
      try
      {
        companyclientDto.Id = id;
        await _companyclientService.EditAsync(companyclientDto);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}
