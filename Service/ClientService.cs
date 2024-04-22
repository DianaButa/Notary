using Microsoft.EntityFrameworkCore;
using Notary.Database;
using Notary.DTO;
using Notary.ExtensionMethod;
using Notary.Models;


namespace Notary.Service
{
  public class ClientService : IClientService
  {
    private readonly ApplicationDbContext _context;

    public ClientService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<ClientDTO>> GetAllAsync()
    {
      var clients = await _context.Clients.ToListAsync();

      var filesDTOs = clients.Select(client => new ClientDTO
      {
        Id = client.Id,
        FirstName = client.FirstName,
        LastName = client.LastName,
        Adress = client.Adress,
        CNP = client.CNP,


      });

      return filesDTOs;
    }



    async Task<ClientDTO> IClientService.GetClientById(int id)
    {
      var client = await _context.Clients.FirstOrDefaultAsync(p => p.Id == id);

      if (client == null)
      {
        return null;
      }

      var clientDTO = new ClientDTO
      {
        Id = client.Id,
        FirstName = client.FirstName,
        LastName= client.LastName,
        Adress= client.Adress,
       
      };

      return clientDTO;
    }

    public async Task AddProduct(ClientDTO clientDTO)
    {
      var newClient = new Client
      {
        FirstName = clientDTO.FirstName,
        LastName = clientDTO.LastName,
        Adress = clientDTO.Adress,
        CNP = clientDTO.CNP,
        Email = clientDTO.Email,
      };

      _context.Clients.Add(newClient);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id)
    {
      var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

      if (client != null)
      {

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
      }
    }
    public async Task EditAsync(ClientDTO clientDTO)
    {
      var client = await _context.Clients.ToListAsync();

      var clients = await _context.Clients.FirstOrDefaultAsync(p => p.Id == clientDTO.Id);


      clients.UpdateModel(clientDTO);
      await _context.SaveChangesAsync();

    }


  }
}
