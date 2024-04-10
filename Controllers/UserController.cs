using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notary.Database;
using Notary.DTO;
using Notary.Service;

namespace Notary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly ApplicationDbContext db;
    private readonly IUserService _userService;

    public UserController(ApplicationDbContext db, IUserService userService)
    {
      this.db = db;
      _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<UserDTO>> GetUsers()
    {
      return await _userService.GetAllAsync();
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddUser(UserDTO userDto)
    {
      try
      {
        await _userService.AddUser(userDto);
        return Ok("Product added successfully.");
      }
      catch (System.Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding product: {ex.Message}");
      }
    }

    [HttpDelete("{id}")]
    public async Task DeletebyId(int id)
    {
      await _userService.DeleteUser(id);
    }


    [HttpPut("edit")]
    public async Task<IActionResult> Edit(int id, [FromBody] UserDTO userDto)
    {
      try
      {
        userDto.Id = id;
        await _userService.EditAsync(userDto);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}
