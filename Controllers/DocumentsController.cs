// Controllers/DocumentsController.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notary.Database;
using Notary.DTO;
using Notary.Service;

namespace Notary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DocumentsController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly IDocumentsService _documentsService;

    public DocumentsController(ApplicationDbContext context, IDocumentsService documentsService)
    {
      _context = context;
      _documentsService = documentsService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocumentsDTO>>> GetAllAsync()
    {
      var documents = await _documentsService.GetAllAsync();
      if (documents == null || !documents.Any())
      {
        return NotFound();
      }
      return Ok(documents);
    }


    [HttpPost("add")]
    public async Task<IActionResult> AddDocument(DocumentsDTO documentsDto)
    {
      try
      {
        await _documentsService.AddDocument(documentsDto);
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
      await _documentsService.DeleteDocument(id);
    }


    [HttpPut("edit")]
    public async Task<IActionResult> Edit(int id, [FromBody] DocumentsDTO documentsDto)
    {
      try
      {
        documentsDto.Id = id;
        await _documentsService.EditAsync(documentsDto);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}
