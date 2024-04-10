using Notary.DTO;

namespace Notary.Service
{
  public interface IFilesCompanyClientService
  {
    Task<IEnumerable<FilesDTO>> GetAllAsync(int companyClientId);
  }
}
