using Microsoft.EntityFrameworkCore;
using Notary.Database;
using Notary.DTO;
using Notary.ExtensionMethod;
using Notary.Models;

namespace Notary.Service
{
  public class userService : IUserService

  {
    private readonly ApplicationDbContext _context;
    public userService(ApplicationDbContext context)
    {
      _context= context;

    }
    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
      var user = await _context.Users.ToListAsync();
      var userDTOs = user.Select(user => new UserDTO
      {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email,
        Password = user.Password,

      });

      return userDTOs;
    }

    public async Task AddUser(UserDTO userDTO)
    {
      var newUser = new User
      {
        Name = userDTO.Name,
        Email = userDTO.Email,
        Password = userDTO.Password,
      };

      _context.Users.Add(newUser);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
      var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

      if (user != null)
      {

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
      }
    }
    public async Task EditAsync(UserDTO userDTO)
    {
      var user = await _context.Users.ToListAsync();

      var users = await _context.Users.FirstOrDefaultAsync(p => p.Id == userDTO.Id);


      users.UpdateModel(userDTO);
      await _context.SaveChangesAsync();

    }

  }
}
