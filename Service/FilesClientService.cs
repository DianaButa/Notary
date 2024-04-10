using Microsoft.EntityFrameworkCore;
using Notary.Database;
using Notary.DTO;

namespace Notary.Service
{
  public class FilesClientService
  {
    private readonly ApplicationDbContext _context;

    public FilesClientService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<FilesDTO>> GetAllAsync(int clientId)
    {
      try
      {
        var z = await _context.FilesCompanyClients.Where(pt => pt.CompanyClientId == clientId).ToListAsync();

      }
      catch (Exception)
      {

        throw;
      }
      var studentClassesDTOs = await _context.FilesCompanyClients
          .Include(pt => pt.files)
          .Where(pt => pt.CompanyClientId == clientId)
          .Select(pt => new FilesDTO()
          {
            Id = pt.files.Id,
            FileName = pt.files.FileName,
            


          })
          .ToListAsync();

      return studentClassesDTOs;
    }

  }
}
