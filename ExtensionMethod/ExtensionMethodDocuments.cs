using Notary.DTO;
using Notary.Models;

namespace Notary.ExtensionMethod
{
  public static class ExtensionMethodDocuments
  {
    public static Documents UpdateModel(this Documents documents, DocumentsDTO documentsDTO)
    {
      if (documentsDTO == null)
      {
        throw new ArgumentNullException(nameof(documentsDTO));
      }
      documents.Id = documentsDTO.Id;
      documents.Name = documentsDTO.Name;
      documents.Description = documentsDTO.Description;


      return documents;
    }
  }
}
