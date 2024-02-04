using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>().Property(m => m.RestorationId).IsRequired(false);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Book>()
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

      public  DbSet<Member> Members { get; set; }
      public  DbSet<Book> Books { get; set; }

        public DbSet<Order> Orders { get; set; }

       public DbSet<Category> Categories { get; set; }

       public DbSet<Item> Items { get; set; }

        public DbSet<Restoration> Restorations { get; set; }

    }
}
