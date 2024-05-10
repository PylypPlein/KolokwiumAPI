using KolokwiumAPI.Dto;

namespace KolokwiumAPI.Repositories;

public interface IClientRepository
{
    public bool DeleteClient(DeleteClientDto client);
}
public class ClientRepository
{
    private readonly IConfiguration _configuration;

    public ClientRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool DeleteClient(DeleteClientDto client)
    {

        return true;
    }
}