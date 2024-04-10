using Notary.DTO;

namespace Notary.Service
{
  public interface IFilesClientService
  {

    Task<IEnumerable<FilesDTO>> GetAllAsync(int clientId);
  }
}
