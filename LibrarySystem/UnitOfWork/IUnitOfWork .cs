using LibrarySystem.Models;
using LibrarySystem.Repositories;

namespace LibrarySystem.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBaseRepository<Category> Categories { get; set; }
        IBaseRepository<Book> Books { get; set; }
        IBaseRepository<Member> Members { get; set; }
        IBaseRepository<Order> Orders { get; set; }
        IBaseRepository<Restoration> Restorations { get; set; }
        IBaseRepository<Item> Items { get; set; }





        int Complete();
    }
}
