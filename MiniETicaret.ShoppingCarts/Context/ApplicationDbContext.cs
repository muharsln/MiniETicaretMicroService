using Microsoft.EntityFrameworkCore;
using MiniETicaret.ShoppingCarts.Models;

namespace MiniETicaret.ShoppingCarts.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
}
