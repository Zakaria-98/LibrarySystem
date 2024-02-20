using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class RestorationService:IRestorationService
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        public RestorationService(ApplicationDbContext context, IUnitOfWork unitofwork)
        {
            _context = context;
            _unitofwork = unitofwork;
        }
        public async Task<IEnumerable<RestorationOutputDto>> GetAllRestorations()
        {
            var restorations = await _unitofwork.Restorations.GetAllAsync((o => new RestorationOutputDto
            {
                Id = o.Id,
                RestorationDate = o.RestorationDate,
                OrderId = o.Order.Id

            }));
               
            return restorations;

        }

        public async Task<bool> AddRestoration(int id)
        {

            var order = await _unitofwork.Orders.GetByIdAsync(id);

            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

            var restoration = new Restoration
            {
                RestorationDate = DateTime.Now
            };
            restoration.Order = new Order();
            order = await _unitofwork.Orders.GetByIdAsync(id);
            restoration.Order=order;

            var items = await _unitofwork.Items.GetListAsync(o => o.OrderId == id,
                g => new Item
                {
                    BookId = g.BookId,
                    BookQuantity = g.BookQuantity
                });


            foreach (var item in items)
            {
                var book = await _unitofwork.Books.GetByIdAsync(item.BookId);
                book.AvailableQuantity += item.BookQuantity;
            }

            await _unitofwork.Restorations.AddAsync(restoration);
            _unitofwork.Complete();
            return true;

        }


        public async Task<bool> DeleteRestoration(int id)
        {
            var restoration = await _unitofwork.Restorations.FindByIdAsync(o => o.Id == id, new[] { "Order" });

            if (restoration == null)
                return false;
            var order = await _unitofwork.Orders.GetByIdAsync(restoration.Order.Id);




            var items = await _unitofwork.Items.GetListAsync(o => o.OrderId == order.Id,
                g => new Item
                {
                    BookId = g.BookId,
                    BookQuantity = g.BookQuantity
                   
                });


            var book = new Book();
            foreach (var item in items)
            {
                book = await _unitofwork.Books.GetByIdAsync(item.BookId);
                book.AvailableQuantity -= item.BookQuantity;
            }

            _unitofwork.Restorations.Delete(restoration);
            _unitofwork.Complete();
            return true;

        }
    }
}
