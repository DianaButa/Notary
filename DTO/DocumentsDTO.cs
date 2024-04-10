namespace Notary.DTO
{
  public class DocumentsDTO
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int CompanyClientId { get; set; }

    public int ClientId { get; set; }
  }
}
