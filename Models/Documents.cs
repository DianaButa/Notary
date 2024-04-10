namespace Notary.Models
{
  public class Documents
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int ClientId { get; set; } 

    public Client Client { get; set; }

    public CompanyClient CompanyClient { get; set; }

    public int CompanyClientId { get; set; }

    public ICollection<DocumentsFiles> DocumentsFiles { get; set; }


   
  }
}
