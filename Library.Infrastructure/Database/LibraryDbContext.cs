using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Database;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}