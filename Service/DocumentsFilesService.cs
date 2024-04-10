using Microsoft.EntityFrameworkCore;
using Notary.Database;
using Notary.DTO;

namespace Notary.Service
{
  public class DocumentsFilesService
  {
    private readonly ApplicationDbContext _context;

    public DocumentsFilesService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<DocumentsDTO>> GetAllAsync(int filesId)
    {
      try
      {
        var z = await _context.DocumentsFiles.Where(pt => pt.FilesId == filesId).ToListAsync();

      }
      catch (Exception)
      {

        throw;
      }
      var studentClassesDTOs = await _context.DocumentsFiles
          .Include(pt => pt.documents)
          .Where(pt => pt.FilesId == filesId)
          .Select(pt => new DocumentsDTO()
          {
            Id = pt.documents.Id,
            Name = pt.documents.Name,
            

          })
          .ToListAsync();

      return studentClassesDTOs;
    }

  }
}

