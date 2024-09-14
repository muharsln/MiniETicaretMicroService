using Bogus;
using Microsoft.EntityFrameworkCore;
using MiniETicaret.Products.Context;
using MiniETicaret.Products.Dtos;
using MiniETicaret.Products.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/seedData", (ApplicationDbContext context) =>
{
    for (int i = 0; i < 100; i++)
    {
        Faker faker = new();
        Product product = new()
        {
            Name = faker.Commerce.ProductName(),
            Price = Convert.ToDecimal(faker.Commerce.Price()),
            Stock = faker.Commerce.Random.Int(1, 100)
        };
        context.Products.Add(product);
    }
    context.SaveChanges();

    return Results.Ok("Seed data başarıyla çalıştırıldı ve ürünler oluşturuldu");
});

app.MapGet("/getall", async (ApplicationDbContext context, CancellationToken cancellationToken) =>
{
    var products = await context.Products.OrderBy(p => p.Name).ToListAsync(cancellationToken);

    return products;
});

app.MapPost("/create", async (CreateProductDto request, ApplicationDbContext context, CancellationToken cancellationToken) =>
{
    bool isNameExists = await context.Products.AnyAsync(p => p.Name == request.Name, cancellationToken);
    if (isNameExists)
    {
        return Results.BadRequest("Ürün adı daha önce oluşturulmuş");
    }

    Product product = new()
    {
        Name = request.Name,
        Price = request.Price,
        Stock = request.Stock
    };

    await context.AddAsync(product, cancellationToken);
    await context.SaveChangesAsync(cancellationToken);

    return Results.Ok("Ürün kaydı başarıyla oluşturuldu");

});

using (var scoped = app.Services.CreateScope())
{
    var srv = scoped.ServiceProvider;
    var context = srv.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.Run();
