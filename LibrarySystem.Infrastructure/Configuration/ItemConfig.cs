using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibrarySystem.Configuration
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(p => p.OrderId).IsRequired();
            builder.Property(p => p.BookId).IsRequired();
            builder.Property(p => p.BookQuantity).IsRequired();







        }
    }
}
