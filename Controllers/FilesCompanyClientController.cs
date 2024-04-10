using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notary.Database;
using Notary.DTO;
using Notary.Service;

namespace Notary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FilesCompanyClientController : ControllerBase
  {
    private readonly ApplicationDbContext db;
    private readonly IFilesCompanyClientService _filesCompanyClientService;

    public FilesCompanyClientController(ApplicationDbContext db, IFilesCompanyClientService filesCompanyClientService)
    {
      this.db = db;
      _filesCompanyClientService = filesCompanyClientService;
    }



    [HttpGet("{id}")]
    public async Task<IEnumerable<FilesDTO>> GetStudentClasses(int id)
    {
      return await _filesCompanyClientService.GetAllAsync(id);


    }
  }
}
