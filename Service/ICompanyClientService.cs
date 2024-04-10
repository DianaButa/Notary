using Notary.DTO;

namespace Notary.Service
{
  public interface ICompanyClientService
  {
    Task<CompanyClientDTO> GetCompanyClientById(int id);

    Task AddCompanyClient(CompanyClientDTO companyClientDTO);

    Task DeleteCompanyClient(int Id);

    public Task EditAsync(CompanyClientDTO companyClientDto);
  }
}
