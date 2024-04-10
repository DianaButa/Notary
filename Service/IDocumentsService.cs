// Service/IDocumentsService.cs
using Notary.DTO;
using Notary.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Notary.Service
{
  public interface IDocumentsService
  {
    Task<DocumentsDTO> GetDocumentById(int id);
    Task<IEnumerable<DocumentsDTO>> GetAllAsync();
    Task AddDocument(DocumentsDTO documentsDTO);

    Task DeleteDocument(int Id);

    public Task EditAsync(DocumentsDTO documentsDto);

  }
}
