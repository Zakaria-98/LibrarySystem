using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibrarySystem.Configuration
{
    public class RestorationConfig : IEntityTypeConfiguration<Restoration>
    {
        public void Configure(EntityTypeBuilder<Restoration> builder)
        {
            builder.Property(p => p.RestorationDate).IsRequired();


        }
    }
}
