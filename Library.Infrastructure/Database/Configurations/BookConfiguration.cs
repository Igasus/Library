using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Database.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasMany(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity<AuthorBook>(
                j => j
                    .HasOne(ab => ab.Author)
                    .WithMany(a => a.AuthorsBooks)
                    .HasForeignKey(ab => ab.AuthorId),
                j => j
                    .HasOne(ab => ab.Book)
                    .WithMany(b => b.AuthorsBooks)
                    .HasForeignKey(ab => ab.BookId));

        builder.OwnsOne(b => b.CreationAddress);
    }
}