namespace MiniETicaret.Products.Dtos;

public sealed record CreateProductDto(
    string Name,
    decimal Price,
    int Stock);