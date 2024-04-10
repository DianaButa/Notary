using Notary.Controllers;
using Notary.DTO;
using Notary.Models;

namespace Notary.Service
{
  public interface IClientService
  {
    Task<ClientDTO> GetClientById(int id);

    Task AddProduct(ClientDTO clientDTO);

    Task DeleteProduct(int Id);

    public Task EditAsync(ClientDTO clientDto);

    Task<IEnumerable<ClientDTO>> GetAllAsync();


  }
}
