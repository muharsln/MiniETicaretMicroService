namespace MiniETicaret.ShoppingCarts.Models;

public class ShoppingCart
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public ShoppingCart()
    {
        Id = Guid.NewGuid();
    }
}
