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

           

            
        }
    }
}
