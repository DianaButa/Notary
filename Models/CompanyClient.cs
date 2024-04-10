namespace Notary.Models
{
  public class CompanyClient
  {
    public int Id { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string ContactAdress { get; set; } = string.Empty;

    public string CompanyAddress { get; set; } = string.Empty;

    public string CIF { get; set; } = string.Empty;

    public string CUI { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public ICollection<Documents> Documents { get; set; }

    public ICollection<FilesCompanyClient> FilesCompanyClient { get; set; }
  }
}
