namespace MiniETicaret.Orders.Options;

public sealed record MongoDbSettings
{
    public string ConnectionString { get; set; } = default!;
    public string DatabaseName { get; set; } = default!;
}
