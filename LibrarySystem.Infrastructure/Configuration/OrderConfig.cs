using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibrarySystem.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.RestorationDate).IsRequired();
            builder.Property(p => p.MemberId).IsRequired();
            builder.Property(p => p.RestorationId).IsRequired(false);


        }
    }
}
