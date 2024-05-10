using KolokwiumAPI.Dto;
using KolokwiumAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumAPI.Controllers;

[ApiController]
[Route("/api/client")]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult DeleteClient(int id, [FromBody] DeleteClientDto deleteClientDto)
    {
        var succes = _service.DeleteClient(id,deleteClientDto);
        return succes ? StatusCode(StatusCodes.Status200OK) : Conflict();
    }
}