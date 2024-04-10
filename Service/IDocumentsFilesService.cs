using Notary.DTO;

namespace Notary.Service
{
  public interface IDocumentsFilesService
  {

    Task<IEnumerable<DocumentsDTO>> GetAllAsync(int id);
    }
}
