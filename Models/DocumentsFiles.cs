using System.ComponentModel.DataAnnotations;

namespace Notary.Models
{
  public class DocumentsFiles
  {

    [Key]
    public int Id { get; set; }
    [Required]
    public int DocumentsId { get; set; }
    [Required]
    public int FilesId { get; set; }

    [Required]
    public Documents documents { get; set; }
    [Required]
    public Files files { get; set; }
  }
}
