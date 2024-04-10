
namespace Notary.Models
{
  public class Files
  {
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;


    public ICollection<FilesClient> FilesClient { get; set; }

    public ICollection<FilesCompanyClient> FilesCompanyClient { get; set; }

    public ICollection<DocumentsFiles> DocumentsFiles { get; set; }
  }
}
