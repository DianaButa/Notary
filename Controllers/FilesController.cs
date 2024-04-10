// Controllers/FilesController.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notary.Database;
using Notary.DTO;
using Notary.Models;
using Notary.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FilesController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly IFilesService _filesService;

    public FilesController(ApplicationDbContext context, IFilesService filesService)
    {
      _context = context;
      _filesService = filesService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FilesDTO>>> GetFiles()
    {
      var files = await _filesService.GetAllAsync();
      if (files == null || !files.Any())
      {
        return NotFound();
      }
      return Ok(files);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FilesDTO>> GetFile(int id)
    {
      var file = await _filesService.GetFileById(id);
      if (file == null)
      {
        return NotFound();
      }
      return Ok(file);
    }


    [HttpPost("add")]
    public async Task<IActionResult> AddFile(FilesDTO filesDto)
    {
      try
      {
        await _filesService.AddProduct(filesDto);
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
      await _filesService.DeleteProduct(id);
    }

    [HttpPut("edit")]
    public async Task<IActionResult> Edit(int id, [FromBody] FilesDTO filesDto)
    {
      try
      {
        filesDto.Id = id;
        await _filesService.EditAsync(filesDto);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

  }



  }

