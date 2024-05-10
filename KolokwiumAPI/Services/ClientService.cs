using KolokwiumAPI.Dto;
using KolokwiumAPI.Repositories;

namespace KolokwiumAPI.Services;

public interface IClientService
{
    public bool DeleteClient(DeleteClientDto deleteClientDto);
}
public class ClientService
{
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }
    public bool DeleteClient(DeleteClientDto deleteClientDto)
    {
        return _repository.DeleteClient(deleteClientDto);
    }
}