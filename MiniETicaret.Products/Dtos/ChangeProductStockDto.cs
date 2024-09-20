namespace MiniETicaret.Products.Dtos;

public sealed record ChangeProductStockDto(
    Guid ProductId,
    int Quantity);
