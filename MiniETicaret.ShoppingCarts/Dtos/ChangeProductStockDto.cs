namespace MiniETicaret.ShoppingCarts.Dtos;

public sealed record ChangeProductStockDto(
    Guid ProductId,
    int Quantity);
