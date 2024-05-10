using KolokwiumAPI.Dto;

namespace KolokwiumAPI.Repositories;
using System.Data.SqlClient;
public interface IOrderRepository
{
    public IEnumerable<OrderDto> GetOrderDetails(int IdOrder);
}
public class OrderRepository : IOrderRepository
{
    private readonly IConfiguration _configuration;
    public OrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IEnumerable<OrderDto> GetOrderDetails(int orderId)
    {
        var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        using (connection)
        {
            var query = "SELECT o.IdOrder, o.Name AS OrderName, o.Description AS OrderDescription, o.CreationDate, " +
                        "p.IdProduct, p.Name AS ProductName, p.Price, op.Quantity " +
                        "FROM [Order] o " +
                        "INNER JOIN Order_Product op ON o.IdOrder = op.IdOrder " +
                        "INNER JOIN Product p ON op.IdProduct = p.IdProduct " +
                        "WHERE o.IdOrder = @OrderId " +
                        "ORDER BY p.Name DESC";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderId", orderId);

            connection.Open();
            var reader = command.ExecuteReader();

            var orderDetails = new List<OrderDto>();
            while (reader.Read())
            {
                var orderDto = new OrderDto
                {
                    IdOrder = Convert.ToInt32(reader["IdOrder"]),
                    Name = reader["OrderName"].ToString(),
                    Description = reader["OrderDescription"].ToString(),
                    Date = Convert.ToDateTime(reader["CreationDate"]),
                    Products = new List<ProductDto>
                    {
                        new ProductDto
                        {
                            IdProduct = Convert.ToInt32(reader["IdProduct"]),
                            Name = reader["ProductName"].ToString(),
                            Price = Convert.ToDouble(reader["Price"]),
                        }
                    }
                };
                orderDetails.Add(orderDto);
            }
            reader.Close();

            return orderDetails;
        }
    }

}