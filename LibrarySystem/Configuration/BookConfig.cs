using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Configuration
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(150);

            builder.Property(p => p.CategoryId).IsRequired();

            builder
                 .HasMany(o => o.Orders)
                 .WithMany(m => m.Books)
                 .UsingEntity<Item>(
                 i => i
                 .HasOne(or => or.Order)
                 .WithMany(it => it.Items)
                 .HasForeignKey(or => or.OrderId),
                 i => i
                 .HasOne(m => m.Book)
                 .WithMany(it => it.Items)
                 .HasForeignKey(or => or.BookId),
                 i =>
                 {
                     i.HasKey(t => new { t.OrderId, t.BookId });
                 }
                 );


        }
    }
}
