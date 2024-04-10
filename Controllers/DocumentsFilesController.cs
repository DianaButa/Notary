using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notary.Database;
using Notary.DTO;
using Notary.Service;

namespace Notary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DocumentsFilesController : ControllerBase
  {
    private readonly ApplicationDbContext db;
    private readonly IDocumentsFilesService _documentsFilesService;

    public DocumentsFilesController(ApplicationDbContext db, IDocumentsFilesService documentsFilesService)
    {
      this.db = db;
      _documentsFilesService = documentsFilesService;
    }



    [HttpGet("{id}")]
    public async Task<IEnumerable<DocumentsDTO>> Get(int id)
    {
      return await _documentsFilesService.GetAllAsync(id);


    }
  }
}
