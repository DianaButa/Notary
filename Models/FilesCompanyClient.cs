using System.ComponentModel.DataAnnotations;

namespace Notary.Models
{
  public class FilesCompanyClient
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public int FilesId {get; set; }
    [Required]
    public int CompanyClientId { get; set; }

    public CompanyClient companyClient { get; set; }

    public Files files { get; set; }
  }
}
