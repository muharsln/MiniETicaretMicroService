using MiniETicaret.Orders.Context;
using MiniETicaret.Orders.Dtos;
using MiniETicaret.Orders.Models;
using MiniETicaret.Orders.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/getall", async (MongoDbContext context, IConfiguration configuration) =>
{
    var items = context.GetCollection<Order>("Orders");

    var orders = await items.Find(items => true).ToListAsync();

    List<OrderDto> ordersDtos = new();

    List<ProductDto>? products = new();

    HttpClient httpClient = new();

    string productEndpoint = $"http://{configuration.GetSection("HttpRequest:Products").Value}/getall";

    var message = await httpClient.GetAsync(productEndpoint);

    if (message.IsSuccessStatusCode)
    {
        products = await message.Content.ReadFromJsonAsync<List<ProductDto>>();
    }

    foreach (var order in orders)
    {
        OrderDto orderDto = new()
        {
            Id = order.Id,
            CreatAt = DateTime.Now,
            ProductId = order.ProductId,
            Quantity = order.Quantity,
            Price = order.Price,
            ProductName = products!.First(p => p.Id == order.ProductId).Name
        };

        ordersDtos.Add(orderDto);
    }

    return Results.Ok(new List<OrderDto>(ordersDtos));
});

app.MapPost("/create", async (MongoDbContext context, List<CreateOrderDto> request) =>
{
    var items = context.GetCollection<Order>("Orders");
    List<Order> orders = new();
    foreach (var item in request)
    {
        Order order = new()
        {
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            Price = item.Price,
            CreatAt = DateTime.Now
        };

        orders.Add(order);
    }

    await items.InsertManyAsync(orders);

    return Results.Ok("Sipariş başarıyla oluşturuldu");
});

app.Run();
