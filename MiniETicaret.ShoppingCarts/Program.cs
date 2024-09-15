using Microsoft.EntityFrameworkCore;
using MiniETicaret.ShoppingCarts.Context;
using MiniETicaret.ShoppingCarts.Dtos;
using MiniETicaret.ShoppingCarts.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/getall", async (ApplicationDbContext context, CancellationToken cancellationToken) =>
{
    List<ShoppingCart> shoppingCarts = await context.ShoppingCarts.ToListAsync(cancellationToken);

    HttpClient client = new HttpClient();

    var message = await client.GetAsync("http://products:8080/getall");

    List<ProductDto>? products = new();

    if (message.IsSuccessStatusCode)
    {
        products = await message.Content.ReadFromJsonAsync<List<ProductDto>>();
    }

    List<ShoppingCartDto> response = shoppingCarts.Select(s => new ShoppingCartDto()
    {
        Id = s.Id,
        ProductId = s.ProductId,
        Quantity = s.Quantity,
        ProductName = products!.First(p => p.Id == s.ProductId).Name,
        ProductPrice = products!.First(p => p.Id == s.ProductId).Price
    }).ToList();

    return response;
});

app.MapPost("/create", async (CreateShoppingCartDto request, ApplicationDbContext context, CancellationToken cancellationToken) =>
{
    ShoppingCart shoppingCart = new()
    {
        ProductId = request.ProductId,
        Quantity = request.Quantity
    };

    await context.AddAsync(shoppingCart, cancellationToken);
    await context.SaveChangesAsync(cancellationToken);

    return Results.Ok("Ürün sepete başarıyla eklendi");
});

using (var scoped = app.Services.CreateScope())
{
    var srv = scoped.ServiceProvider;
    var context = srv.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.Run();
