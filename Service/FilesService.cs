// Service/FilesService.cs
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
  public class FilesService : IFilesService
  {
    private readonly ApplicationDbContext _context;

    public FilesService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<FilesDTO>> GetAllAsync()
    {
      var files = await _context.Files.ToListAsync();

      var filesDTOs = files.Select(file => new FilesDTO
      {
        Id = file.Id,
        FileName = file.FileName,
       
      });

      return filesDTOs;
    }

    public async Task<FilesDTO> GetFileById(int id)
    {
      var file = await _context.Files.FirstOrDefaultAsync(p => p.Id == id);

      if (file == null)
      {
        return null;
      }

      var fileDTO = new FilesDTO
      {
        Id = file.Id,
        FileName = file.FileName,
       
      };

      return fileDTO;
    }

    public Files GetFile(int id)
    {
      return _context.Files.Find(id);
    }


    public async Task AddProduct(FilesDTO filesDTO)
    {
      var newFile = new Files
      {

        Id = filesDTO.Id,
        FileName = filesDTO.FileName,
     
       
      };

      _context.Files.Add(newFile);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id)
    {
      var file = await _context.Files.FirstOrDefaultAsync(x => x.Id == id);

      if (file != null)
      {

        _context.Files.Remove(file);
        await _context.SaveChangesAsync();
      }
    }

    public async Task EditAsync(FilesDTO filesDTO)
    {
      var file = await _context.Files.ToListAsync();

      var files = await _context.Files.FirstOrDefaultAsync(p => p.Id == filesDTO.Id);


      files.UpdateModel(filesDTO);
      await _context.SaveChangesAsync();

    }




  }
  }

