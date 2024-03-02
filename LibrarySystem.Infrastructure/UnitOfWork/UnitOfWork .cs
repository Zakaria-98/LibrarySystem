using LibrarySystem.Models;
using LibrarySystem.Repositories;

namespace LibrarySystem.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Category> Categories { get;  set; }
        public IBaseRepository<Book> Books { get; set; }

        public IBaseRepository<Member> Members { get; set; }
        public IOrderRepository  Orders { get; set; }

        public IRestorationRepository Restorations { get; set; }
        public IItemRepository Items { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Categories = new BaseRepository<Category>(_context);
            Books = new BaseRepository<Book>(_context);
            Members = new BaseRepository<Member>(_context);
            Orders = new OrderRepository(_context);
            Restorations = new RestorationRepository(_context);
            Items = new ItemRepository(_context);



        }

        public int Complete()
        {
           return _context.SaveChanges();

        }
    }
}
