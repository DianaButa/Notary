using Notary.DTO;

namespace Notary.Service
{
  public interface IUserService
  {
    Task<IEnumerable<UserDTO>> GetAllAsync();

    Task AddUser(UserDTO userDTO);

    Task DeleteUser(int Id);

    public Task EditAsync(UserDTO userDto);
  }
}
