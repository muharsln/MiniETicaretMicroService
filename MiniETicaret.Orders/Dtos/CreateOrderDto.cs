namespace MiniETicaret.Orders.Dtos;

public sealed record CreateOrderDto(
    Guid ProductId,
    int Quantity,
    decimal Price);
