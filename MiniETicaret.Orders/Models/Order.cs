namespace MiniETicaret.Orders.Models;

public sealed class Order
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatAt { get; set; }

    public Order()
    {
        Id = Guid.NewGuid();
    }
}
