using Notary.DTO;
using Notary.Models;

namespace Notary.ExtensionMethod
{
  public static class ExtensionMethodFiles
  {
    public static Files UpdateModel(this Files files, FilesDTO filesDTO)
    {
      if (filesDTO == null)
      {
        throw new ArgumentNullException(nameof(filesDTO));
      }

      files.FileName = filesDTO.FileName;
     

      return files;
    }

  }
}
