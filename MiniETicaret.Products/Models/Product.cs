namespace MiniETicaret.Products.Models;

public sealed class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Product()
    {
        Id = Guid.NewGuid();
    }
}
