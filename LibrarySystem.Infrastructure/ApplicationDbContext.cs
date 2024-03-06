using LibrarySystem.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Models
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            new BookConfig().Configure(modelBuilder.Entity<Book>());
            new CategoryConfig().Configure(modelBuilder.Entity<Category>());
            new ItemConfig().Configure(modelBuilder.Entity<Item>());
            new OrderConfig().Configure(modelBuilder.Entity<Order>());
            new RestorationConfig().Configure(modelBuilder.Entity<Restoration>());


            /* modelBuilder.Entity<Order>().Property(m => m.RestorationId).IsRequired(false);
             base.OnModelCreating(modelBuilder); */


            /* modelBuilder.Entity<Book>()
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
                 ); */



            /*  modelBuilder.Entity<Item>()
                   .HasOne(or => or.Order)
                   .WithMany(it => it.Items)
                   .HasForeignKey(or => or.OrderId);

               modelBuilder.Entity<Item>()
                  .HasOne(m => m.Book)
                   .WithMany(it => it.Items)
                   .HasForeignKey(or => or.BookId);

                    modelBuilder.Entity<Item>().HasKey(t => new { t.OrderId, t.BookId }); */

        }

        public  DbSet<Member> Members { get; set; }
      public  DbSet<Book> Books { get; set; }

        public DbSet<Order> Orders { get; set; }

       public DbSet<Category> Categories { get; set; }

       public DbSet<Item> Items { get; set; }

        public DbSet<Restoration> Restorations { get; set; }


    }
}
