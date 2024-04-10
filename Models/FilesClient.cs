using System.ComponentModel.DataAnnotations;

namespace Notary.Models
{
  public class FilesClient
  {

    [Key]
    public int Id { get; set; }
    [Required]
    public int ClientId { get; set; }
    [Required]
    public int FilesId { get; set; }

    
    public Client client { get; set; }
    
    public Files files { get; set; }
  }
}
