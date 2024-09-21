using Microsoft.EntityFrameworkCore;
using MiniETicaret.Gateway.Models;

namespace MiniETicaret.Gateway.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
