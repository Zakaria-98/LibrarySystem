using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibrarySystem.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        private ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task<IEnumerable<DisplayOutput>> GetListOrdersAsync(Expression<Func<Item, bool>> where)
        {
            var result = await _context.Items.Where(where).Select(
                o => new DisplayOutput
                {
                    Id = o.Order.Id,
                    MemberName = o.Order.Member.Name,
                    OrderDate = o.Order.OrderDate,
                    RestorationBeforeDate = o.Order.RestorationDate,
                    RestorationDate = o.Order.Restoration.RestorationDate,
                    Items = o.Order.Items.Select(i => new OrderItemsOutputDto
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
