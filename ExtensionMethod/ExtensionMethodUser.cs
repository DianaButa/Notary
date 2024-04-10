using Notary.DTO;
using Notary.Models;

namespace Notary.ExtensionMethod
{
  public static class ExtensionMethodUser
  {
    public static User UpdateModel(this User user, UserDTO userDTO)
    {
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user));
      }

      if (userDTO == null)
      {
        throw new ArgumentNullException(nameof(userDTO));
      }

     
      user.Id = userDTO.Id;
      user.Name = userDTO.Name;
      user.Email = userDTO.Email;
      user.Password = userDTO.Password;

      return user;
    }


  }
}
