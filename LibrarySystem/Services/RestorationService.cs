using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class RestorationService:IRestorationService
    {
        private ApplicationDbContext _context;
        public RestorationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RestorationOutputDto>> GetAllRestorations()
        {
            var restorations = await _context.Restorations.Include(o => o.Orders).Select(o => new RestorationOutputDto
            {
                Id = o.Id,
                RestorationDate = o.RestorationDate,
                OrderId = o.Orders.SingleOrDefault(r => r.RestorationId == o.Id).Id



            })
                .ToListAsync();
            return restorations;

        }

        public async Task<bool> AddRestoration(int id)
        {

            var order = await _context.Orders.SingleOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

            var restoration = new Restoration
            {
                RestorationDate = DateTime.Now
            };
            restoration.Orders = new List<Order>();
            order = await _context.Orders.SingleOrDefaultAsync(o => o.Id == id);
            restoration.Orders.Add(order);

            var items = _context.Items.Where(o => o.OrderId == id).ToList()
                .Select(g => new
                {
                    BookId = g.BookId,
                    BookQuantity = g.BookQuantity
                });


            foreach (var item in items)
            {
                var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == item.BookId);
                book.AvailableQuantity += item.BookQuantity;
            }

            await _context.Restorations.AddAsync(restoration);
            _context.SaveChanges();
            return true;

        }


        public async Task<bool> DeleteRestoration(int id)
        {
            var restoration = await _context.Restorations.SingleOrDefaultAsync(o => o.Id == id);
            var order = await _context.Orders.SingleOrDefaultAsync(o => o.RestorationId == id);

            if (restoration == null)
                return false;


            var items = _context.Items.Where(o => o.OrderId == order.Id).ToList()
                        .Select(g => new
                        {
                            BookId = g.BookId,
                            BookQuantity = g.BookQuantity
                        });



            var book = new Book();
            foreach (var item in items)
            {
                book = await _context.Books.SingleOrDefaultAsync(b => b.Id == item.BookId);
                book.AvailableQuantity -= item.BookQuantity;
            }

            _context.Remove(restoration);
            _context.SaveChanges();
            return true;

        }
    }
}
