

namespace Notary.Models
{
  public class Client
  {
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Adress { get; set; } = string.Empty;

    public string CNP { get; set; } = string.Empty; 


    public string Email { get; set; } = string.Empty;

   

    public ICollection<FilesClient> FilesClient { get; set; }

    public ICollection<Documents> Documents { get; set; }
  }
}
