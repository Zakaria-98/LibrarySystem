using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace LibrarySystem.Repositories
{
    public class OrderRepository:BaseRepository<Order>, IOrderRepository
    {
        private ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context):base(context)
        {
            _context = context;

        }

        public async Task<IEnumerable<DisplayOutput>> GetAllOrdersAsync () 
        {
            var result = await _context.Orders.Select(o => new DisplayOutput
            {
                Id = o.Id,
                MemberId = o.MemberId,
                MemberName = o.Member.Name,
                OrderDate = o.OrderDate,
                RestorationBeforeDate = o.RestorationDate,
                RestorationDate = o.Restoration.RestorationDate,
                Items = o.Items.Select(i => new OrderItemsOutputDto
                {
                    BookId = i.BookId,
                    BookName = i.Book.Title,
                    BookQuantity = i.BookQuantity
                }).ToList()
            }).ToListAsync();


            if (result == null)
                return null;

            return result;
        }

        public async Task<DisplayOutput> GetByIdOrderAsync(int id)
        {
            var result = await _context.Orders.Select(
               o => new DisplayOutput
               {
                   Id = o.Id,
                   MemberId = o.MemberId,
                   MemberName = o.Member.Name,
                   OrderDate = o.OrderDate,
                   RestorationBeforeDate = o.RestorationDate,
                   RestorationDate = o.Restoration.RestorationDate,
                   Items = o.Items.Select(i => new OrderItemsOutputDto
                   {
                       BookId = i.BookId,
                       BookName = i.Book.Title,
                       BookQuantity = i.BookQuantity
                   }).ToList()
               }).FirstOrDefaultAsync(o => o.Id == id);

            if (result == null)
                return null;

            return result;
        }

        public async Task<IEnumerable<DisplayOutput>> GetListOrdersAsync(Expression<Func<Order, bool>> where) 
        {
            var result = await _context.Orders.Where(where).Select(
               o => new DisplayOutput
               {
                   Id = o.Id,
                   MemberId = o.MemberId,
                   MemberName = o.Member.Name,
                   OrderDate = o.OrderDate,
                   RestorationBeforeDate = o.RestorationDate,
                   RestorationDate = o.Restoration.RestorationDate,
                   Items = o.Items.Select(i => new OrderItemsOutputDto
                   {
                       BookId = i.BookId,
                       BookName = i.Book.Title,
                       BookQuantity = i.BookQuantity
                   }).ToList()
               }).ToListAsync();
            if (result == null)
                return null;

            return result;
        }


    }
}
