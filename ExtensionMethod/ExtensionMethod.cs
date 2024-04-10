using Notary.DTO;
using Notary.Models;

namespace Notary.ExtensionMethod
{
  public static class ExtensionMethod
  {
    public static Client ToNewModel( this ClientDTO clientDTO)
    {
      return new Client()
      {
        FirstName = clientDTO.FirstName,
        LastName = clientDTO.LastName,
        Adress = clientDTO.Adress,
        CNP = clientDTO.CNP,
        Email = clientDTO.Email,
      };
      
    }

    public static Client ToDTO ( this Client clientDTO )
    {
      return new Client()
      {
        FirstName = clientDTO.FirstName,
        LastName = clientDTO.LastName,
        Adress = clientDTO.Adress,
        CNP = clientDTO.CNP,
        Email = clientDTO.Email,

      };
    }

    public static Client UpdateModel( this Client client, ClientDTO clientDTO )
    {
      if (clientDTO == null)
      {
        throw new ArgumentNullException(nameof(clientDTO));
      }

      client.FirstName = clientDTO.FirstName;
      client.LastName = clientDTO.LastName;
      client.Adress = clientDTO.Adress;
      client.CNP = clientDTO.CNP;
      client.Email = clientDTO.Email;

      return client;
    }

  }
}
