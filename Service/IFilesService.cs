// Service/IFilesService.cs
using Notary.DTO;
using Notary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notary.Service
{
  public interface IFilesService
  {
    Task<IEnumerable<FilesDTO>> GetAllAsync();
    Task<FilesDTO> GetFileById(int id);
    Files GetFile(int id);
   
    Task AddProduct(FilesDTO filesDTO);

    Task DeleteProduct(int Id);

    public Task EditAsync(FilesDTO filesDto);
  }
}
