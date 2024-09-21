namespace MiniETicaret.Gateway.Models;

public sealed class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;

    public User()
    {
        Id = Guid.NewGuid();
    }
}
