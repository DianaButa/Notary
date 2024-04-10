using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notary.Database;
using Notary.DTO;
using Notary.Service;

namespace Notary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FilesClientController : ControllerBase
  {
    private readonly ApplicationDbContext db;
    private readonly IFilesClientService _filesClientService;

    public FilesClientController(ApplicationDbContext db, IFilesClientService filesClientService)
    {
      this.db = db;
      _filesClientService = filesClientService;
    }



    [HttpGet("{id}")]
    public async Task<IEnumerable<FilesDTO>> GetStudentClasses(int id)
    {
      return await _filesClientService.GetAllAsync(id);


    }
  }
}
