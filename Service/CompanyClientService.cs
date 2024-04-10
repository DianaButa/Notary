using Microsoft.EntityFrameworkCore;
using Notary.Database;
using Notary.DTO;
using Notary.ExtensionMethod;
using Notary.Models;

namespace Notary.Service
{
  public class CompanyClientService : ICompanyClientService
  {
    private readonly ApplicationDbContext _context;

    public CompanyClientService(ApplicationDbContext context)
    {
      _context = context;
    }

    async Task<CompanyClientDTO> ICompanyClientService.GetCompanyClientById(int id)
    {
      var companyclient = await _context.CompanyClients.FirstOrDefaultAsync(p => p.Id == id);

      if (companyclient == null)
      {
        return null;
      }

      var companyclientDTO = new CompanyClientDTO
      {
        Id = companyclient.Id,
        CompanyName=companyclient.CompanyName,
        CompanyAddress=companyclient.CompanyAddress,
        CIF=companyclient.CIF,
        CUI=companyclient.CUI,
        Email=companyclient.Email,

      };

      return companyclientDTO;
    }

    public async Task AddCompanyClient(CompanyClientDTO companyclientDTO)
    {
      var newCompanyClient = new CompanyClient
      {
        Id = companyclientDTO.Id,
        CompanyName = companyclientDTO.CompanyName,
        CompanyAddress = companyclientDTO.CompanyAddress,
        CIF = companyclientDTO.CIF,
        CUI = companyclientDTO.CUI,
        Email = companyclientDTO.Email,
      };

      _context.CompanyClients.Add(newCompanyClient);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteCompanyClient(int id)
    {
      var companyclient = await _context.CompanyClients.FirstOrDefaultAsync(x => x.Id == id);

      if (companyclient != null)
      {

        _context.CompanyClients.Remove(companyclient);
        await _context.SaveChangesAsync();
      }
    }
    public async Task EditAsync(CompanyClientDTO companyClientDTO)
    {
      var companyclient = await _context.CompanyClients.ToListAsync();

      var companyclients = await _context.CompanyClients.FirstOrDefaultAsync(p => p.Id == companyClientDTO.Id);


      companyclients.UpdateModel(companyClientDTO);
      await _context.SaveChangesAsync();

    }


  }
}
