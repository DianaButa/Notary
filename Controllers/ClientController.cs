namespace Notary.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Notary.Database;
    using Notary.DTO;
    using Notary.Models;
    using Notary.Service;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
  [ApiController]
  public class ClientController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly IClientService _clientService;
        private readonly IMailService _mailService;

    public ClientController(ApplicationDbContext context, IClientService clientService, IMailService mailService)
        {
            _context = context;
            _clientService = clientService;
            _mailService = mailService;
        }




        [HttpPost("verify-iban")]
        public IActionResult VerifyIBAN([FromBody] string iban)
        {
            try
            {
                var apiKey = "ef8aaac043672125b7c4dabbad7482ca753821d3";
                var apiUrl = $"https://api.ibanapi.com/v1/validate/{iban}?api_key={apiKey}";

                var request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "GET"; 

                using (var response = (HttpWebResponse)request.GetResponse())
                using (var responseStream = response.GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    var responseString = reader.ReadToEnd();
                    return Ok(responseString);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Invalid IBAN: {ex.Message}");
            }
        }
  


    [HttpPost("sendemail")]
        public async Task<IActionResult> SendEmail([FromBody] EmailDTO emailDto)
        {
            try
            {
                await _mailService.SendEmailAsync(emailDto);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error sending email: {ex.Message}");
            }

        }


            [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClient()
    {
      var files = await _clientService.GetAllAsync();
      if (files == null || !files.Any())
      {
        return NotFound();
      }
      return Ok(files);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDTO>> GetClient(int id)
    {
      var clientDTO = await _clientService.GetClientById(id);
      if (clientDTO == null)
      {
        return NotFound();
      }
      return clientDTO;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddClient(ClientDTO clientDto)
    {
      try
      {
        await _clientService.AddProduct(clientDto);
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
      await _clientService.DeleteProduct(id);
    }


    [HttpPut("edit")]
    public async Task<IActionResult> Edit(int id, [FromBody] ClientDTO clientDto)
    {
      try
      {
        clientDto.Id = id;
        await _clientService.EditAsync(clientDto);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
  }

