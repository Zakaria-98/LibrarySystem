using LibrarySystem.Core.Models;
using LibrarySystem.Core.Repositories;
using LibrarySystem.Infrastructure.Helpers;
using LibrarySystem.Infrastructure.Repositories;
using LibrarySystem.Models;
using LibrarySystem.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace LibrarySystem.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        private readonly JWT _jwt;
        public IBaseRepository<Category> Categories { get;  set; }
        public IBaseRepository<Book> Books { get; set; }

        public IBaseRepository<Member> Members { get; set; }
        public IOrderRepository  Orders { get; set; }

        public IRestorationRepository Restorations { get; set; }
        public IItemRepository Items { get; set; }

        public IUserRepository Users { get; set; }

        public UnitOfWork(ApplicationDbContext context, UserManager<User> usermanager, RoleManager<IdentityRole> rolemanager, IOptions<JWT> jwt) 
        {
            _context = context;
            _userManager = usermanager;
            _rolemanager = rolemanager;
            _jwt = jwt.Value;

            Categories = new BaseRepository<Category>(_context);
            Books = new BaseRepository<Book>(_context);
            Members = new BaseRepository<Member>(_context);
            Orders = new OrderRepository(_context);
            Restorations = new RestorationRepository(_context);
            Items = new ItemRepository(_context);
            Users = new UserRepository(_context,_userManager,_rolemanager, Options.Create(_jwt));





        }

        public int Complete()
        {
           return _context.SaveChanges();

        }
    }
}
