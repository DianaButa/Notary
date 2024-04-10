using Microsoft.EntityFrameworkCore;
using Notary.Database;
using Notary.DTO;

namespace Notary.Service
{
  public class FilesCompanyClientService :IFilesCompanyClientService
  {
    private readonly ApplicationDbContext _context;

    public FilesCompanyClientService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<FilesDTO>> GetAllAsync(int companyClientId)
    {
      try
      {
        var z = await _context.FilesCompanyClients.Where(pt => pt.CompanyClientId == companyClientId).ToListAsync();

      }
      catch (Exception)
      {

        throw;
      }
      var filescompanyclientDTOs = await _context.FilesCompanyClients
          .Include(pt => pt.files)
          .Where(pt => pt.CompanyClientId == companyClientId)
          .Select(pt => new FilesDTO()
          {
            Id = pt.files.Id,
            FileName = pt.files.FileName,



          })
          .ToListAsync();

      return filescompanyclientDTOs;
    }
  }
}
