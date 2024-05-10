using System.Data.SqlClient;
using KolokwiumAPI.Dto;

namespace KolokwiumAPI.Repositories;

public interface IClientRepository
{
    public bool DeleteClient(int id, DeleteClientDto client);
}
public class ClientRepository : IClientRepository
{
    private readonly IConfiguration _configuration;

    public ClientRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool DeleteClient(int id , DeleteClientDto client)
    {
    var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        
        using (var transaction = connection.BeginTransaction())
        {
            try
            {
                
                using (var deleteOrderProductCommand = new SqlCommand(
                    "DELETE FROM Order_Product WHERE IdOrder IN (SELECT IdOrder FROM [Order] WHERE IdClient = @IdClient)",
                    connection,
                    transaction))
                {
                    deleteOrderProductCommand.Parameters.AddWithValue("@IdClient", id);
                    deleteOrderProductCommand.ExecuteNonQuery();
                }
                using (var deleteOrderCommand = new SqlCommand(
                           "DELETE FROM [Order] WHERE IdClient = @IdClient",
                           connection,
                           transaction))
                {
                    deleteOrderCommand.Parameters.AddWithValue("@IdClient", client.IdClient);
                    deleteOrderCommand.ExecuteNonQuery();
                }
                
                using (var deleteClientCommand = new SqlCommand(
                    "DELETE FROM Client WHERE IdClient = @IdClient",
                    connection,
                    transaction))
                {
                    deleteClientCommand.Parameters.AddWithValue("@IdClient", client.IdClient);
                    int affectedRows = deleteClientCommand.ExecuteNonQuery();
                    
                    if (affectedRows > 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}

}