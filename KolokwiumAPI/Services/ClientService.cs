using KolokwiumAPI.Dto;
using KolokwiumAPI.Repositories;

namespace KolokwiumAPI.Services;

public interface IClientService
{
    public bool DeleteClient(int id , DeleteClientDto deleteClientDto);
}
public class ClientService : IClientService
{
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }
    public bool DeleteClient(int id , DeleteClientDto deleteClientDto)
    {
        return _repository.DeleteClient(id,deleteClientDto);
    }
}