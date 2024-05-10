using KolokwiumAPI.Dto;
using KolokwiumAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumAPI.Controllers;

[ApiController]
[Route("/api/")]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }
    [HttpDelete("client")]
    public IActionResult DeleteClient([FromBody] DeleteClientDto deleteClientDto)
    {
        var succes = _service.DeleteClient(deleteClientDto);
        return succes ? StatusCode(StatusCodes.Status200OK) : Conflict();
    }
}