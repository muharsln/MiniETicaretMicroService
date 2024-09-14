using Microsoft.EntityFrameworkCore;
using MiniETicaret.Products.Models;

namespace MiniETicaret.Products.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(builder =>
        {
            builder.Property(p => p.Price).HasColumnType("money");
        });
    }
}
