namespace KolokwiumAPI.Dto;

public class OrderDto
{
    public int IdOrder { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public List<ProductDto> Products { get; set; }
    public int IdClient { get; set; }
}