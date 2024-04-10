// Service/DocumentsService.cs
using Microsoft.EntityFrameworkCore;
using Notary.Database;
using Notary.DTO;
using Notary.ExtensionMethod;
using Notary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notary.Service
{
  public class DocumentsService : IDocumentsService
  {
    private readonly ApplicationDbContext _context;

    public DocumentsService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<DocumentsDTO> GetDocumentById(int id)
    {
      var document = await _context.Documents.FindAsync(id);

      if (document == null)
      {
        return null;
      }

      return new DocumentsDTO
      {
        Id = document.Id,
        Name = document.Name,

      };
    }

    public async Task<IEnumerable<DocumentsDTO>> GetAllAsync()
    {
      var documents = await _context.Documents.ToListAsync();

      return documents.Select(document => new DocumentsDTO
      {
        Id = document.Id,
        Name = document.Name,

      });
    }


    public async Task AddDocument(DocumentsDTO documentsDTO)
    {
      var newDocument= new Documents
      {
        Id= documentsDTO.Id,
        Name = documentsDTO.Name,
        Description= documentsDTO.Description,
        ClientId = documentsDTO.ClientId,
        CompanyClientId = documentsDTO.CompanyClientId





      };
      try
      {
        _context.Documents.Add(newDocument);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {

        throw;
      }


    }


    public async Task DeleteDocument(int id)
    {
      var document = await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);

      if (document != null)
      {

        _context.Documents.Remove(document);
        await _context.SaveChangesAsync();
      }
    }
    public async Task EditAsync(DocumentsDTO documentsDTO)
    {
      var document = await _context.Documents.ToListAsync();

      var documents = await _context.Documents.FirstOrDefaultAsync(p => p.Id == documentsDTO.Id);


      documents.UpdateModel(documentsDTO);
      await _context.SaveChangesAsync();

    }


  }
}
