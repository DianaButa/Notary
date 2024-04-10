using Notary.DTO;
using Notary.Models;

namespace Notary.ExtensionMethod
{
  public static class ExtensionMethodCompanyClient
  {
    public static CompanyClient UpdateModel(this CompanyClient companyclient, CompanyClientDTO companyClientDTO)
    {
      if (companyClientDTO== null)
      {
        throw new ArgumentNullException(nameof(companyClientDTO));
      }

      companyclient.CompanyName = companyClientDTO.CompanyName;
      companyclient.CompanyAddress = companyClientDTO.CompanyAddress;
      companyclient.CUI= companyClientDTO.CUI;
      companyclient.CIF= companyClientDTO.CIF;
      companyclient.Email= companyClientDTO.Email;

      return companyclient;
    }
  }
}
