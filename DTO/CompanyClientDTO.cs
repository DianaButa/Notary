using Notary.Models;

namespace Notary.DTO
{
  public class CompanyClientDTO
  {
    public int Id { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string ContactAdress { get; set; } = string.Empty;

    public string CompanyAddress { get; set; } = string.Empty;

    public string CIF { get; set; } = string.Empty;

    public string CUI { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;



  }
}
