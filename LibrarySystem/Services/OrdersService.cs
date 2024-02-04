using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class OrdersService : IOrdersService
    {
        private ApplicationDbContext _context;
        public OrdersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrdersListDto>> GetAllOrders()
        {
            var orders = await _context.Orders
                .Join(
                _context.Items,
                order => order.Id,
                Item => Item.OrderId,
                (order, Item) => new OrdersOutputDto
                {
                    Id = order.Id,
                    MemberId = order.MemberId,
                    MemberName = order.Member.Name,
                    OrderDate = order.OrderDate,
                    RestorationBeforeDate = order.RestorationDate,
                    BookId = Item.BookId,
                    BookTitle = Item.Book.Title,
                    BookQuantity = Item.BookQuantity,
                    RestorationDate = order.Restoration.RestorationDate



                }
                ).GroupBy(o => o.Id)
                .Select(g => new OrdersListDto
                {
                    Orders = g.ToList(),



                })
                 .ToListAsync();
            return orders;

        }


        public async Task<Order> GetOrdersByOrderId(int Orderid)
        {


            var orders = _context.Orders.Include(o=>o.Items).SingleOrDefault(o => o.Id==Orderid);
            return orders;

        }

        public async Task<IEnumerable<OrdersListDto>> GetOrderslate()
        {
            var orders = await _context.Orders
                .Join(
                _context.Items,
                order => order.Id,
                Item => Item.OrderId,
                (order, Item) => new OrdersOutputDto
                {
                    Id = order.Id,
                    MemberId = order.MemberId,
                    MemberName = order.Member.Name,
                    OrderDate = order.OrderDate,
                    RestorationBeforeDate = order.RestorationDate,
                    BookId = Item.BookId,
                    BookTitle = Item.Book.Title,
                    BookQuantity = Item.BookQuantity,
                    RestorationDate= order.Restoration.RestorationDate


                }
                ).Where(o => (DateTime.Compare(o.RestorationBeforeDate, DateTime.Now) < 0 && o.RestorationDate == null))
                .GroupBy(o => o.Id)
                .Select(g => new OrdersListDto
                {
                    Orders = g.ToList()
                })
                 .ToListAsync();
            return orders;
        }


        public async Task<IEnumerable<OrdersListDto>> GetOrdersbyOrderDateFilter(DateTime date1, DateTime date2)
        {
            var orders = await _context.Orders
                .Join(
                _context.Items,
                order => order.Id,
                Item => Item.OrderId,
                   (order, Item) => new OrdersOutputDto
                   {
                       Id = order.Id,
                       MemberId = order.MemberId,
                       MemberName = order.Member.Name,
                       OrderDate = order.OrderDate,
                       RestorationBeforeDate = order.RestorationDate,
                       BookId = Item.BookId,
                       BookTitle = Item.Book.Title,
                       BookQuantity = Item.BookQuantity,
                       RestorationDate = order.Restoration.RestorationDate


                   }
                ).Where(o => (DateTime.Compare(date1, o.OrderDate) <= 0 && DateTime.Compare(date2, o.OrderDate) >= 0))
                .GroupBy(o => o.Id)
                .Select(g => new OrdersListDto
                {

                    Orders = g.ToList()
                })
                 .ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<OrdersListDto>> GetOrdersbyRestorationDateFilter(DateTime date1, DateTime date2)
        {
            var orders = await _context.Orders
                .Join(
                _context.Items,
                order => order.Id,
                Item => Item.OrderId,
                (order, Item) => new OrdersOutputDto
                {
                    Id = order.Id,
                    MemberId = order.MemberId,
                    MemberName = order.Member.Name,
                    OrderDate = order.OrderDate,
                    RestorationBeforeDate = order.RestorationDate,
                    BookId = Item.BookId,
                    BookTitle = Item.Book.Title,
                    BookQuantity = Item.BookQuantity,
                    RestorationDate = order.Restoration.RestorationDate


                }
                ).Where(o => (DateTime.Compare(date1, o.RestorationBeforeDate) <= 0 && DateTime.Compare(date2, o.RestorationBeforeDate) >= 0))
                .GroupBy(o => o.Id)
                .Select(g => new OrdersListDto
                {
                    Orders = g.ToList()

                })
                 .ToListAsync();
            return orders;

        }

        public async Task<IEnumerable<OrdersListDto>> GetOrdersByMemberId(int MemberId)
        {

            var orders = await _context.Orders
                .Join(
                _context.Items,
                order => order.Id,
                Item => Item.OrderId,
                (order, Item) => new OrdersOutputDto
                {
                    Id = order.Id,
                    MemberId = order.MemberId,
                    MemberName = order.Member.Name,
                    OrderDate = order.OrderDate,
                    RestorationBeforeDate = order.RestorationDate,
                    BookId = Item.BookId,
                    BookTitle = Item.Book.Title,
                    BookQuantity = Item.BookQuantity,
                    RestorationDate = order.Restoration.RestorationDate


                }
                ).Where(o => o.MemberId == MemberId)
                .GroupBy(o => o.Id)
                .Select(g => new OrdersListDto
                {
                    Orders = g.ToList()

                })
                 .ToListAsync();
            return orders;

        }

        public async Task<IEnumerable<OrdersListDto>> GetOrdersByBookId(int BookId)
        {
            var orders = await _context.Orders
                .Join(
                _context.Items,
                order => order.Id,
                Item => Item.OrderId,
                (order, Item) => new OrdersOutputDto
                {
                    Id = order.Id,
                    MemberId = order.MemberId,
                    MemberName = order.Member.Name,
                    OrderDate = order.OrderDate,
                    RestorationBeforeDate = order.RestorationDate,
                    BookId = Item.BookId,
                    BookTitle = Item.Book.Title,
                    BookQuantity = Item.BookQuantity,
                    RestorationDate = order.Restoration.RestorationDate


                }
                ).Where(o => o.BookId == BookId)
                .GroupBy(o => o.Id)
                .Select(g => new OrdersListDto
                {
                    Orders = g.ToList()

                })
                 .ToListAsync();
            return orders;

        }

        public async Task<bool> AddOrder(OrderDto dto, List<ItemsDto> dto2)
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                RestorationDate = DateTime.Now.AddDays(7),
                MemberId = dto.MemberId,
            };

            order.Items = new List<Item>();

            //var book = new Book();
            foreach (var item in dto2)
            {

                var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == item.BookId);


                if (book == null)
                    return false;


                if (item.BookQuantity > book.AvailableQuantity)
                {
                    return false;

                }
                book.AvailableQuantity = book.AvailableQuantity - item.BookQuantity;

                order.Items.Add(
                     new Item
                     {
                         BookId = item.BookId,
                         Order = order,
                         BookQuantity = item.BookQuantity

                     });
            }

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return true;


        }


        public async Task<bool> IsOrderRestored(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(order => order.Id == id);


            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

            return true;

        }

        public async Task<bool> UpdateOrder(int id, EditOrderDto dto,  List<ItemsDto> dto2)
        {
            
            var order = await _context.Orders.SingleOrDefaultAsync(order => order.Id == id);

            /*
            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

            if (dto.MemberId == null)
                return false; */

            order.OrderDate = dto.OrderDate;
            order.RestorationDate = dto.RestorationDate;

            order.MemberId = dto.MemberId;


            //order.Items = new List<Item>();

            var items = _context.Items.Where(o => o.OrderId == id).ToList()
                .Select(g => new
                {
                    BookId = g.BookId,
                    BookQuantity = g.BookQuantity
                });



            var book = new Book();
            foreach (var item in items)
            {
                book = await _context.Books.SingleOrDefaultAsync(b => b.Id == item.BookId);
                book.AvailableQuantity += item.BookQuantity;
            }


            var items2 = _context.Items.Where(o => o.OrderId == id);
            _context.RemoveRange(items2);



            foreach (var item in dto2)
            {
                book = await _context.Books.SingleOrDefaultAsync(b => b.Id == item.BookId);

                if (book == null)
                    return false;

                if (item.BookQuantity > book.AvailableQuantity)
                {
                    return false;

                }
                book.AvailableQuantity -= item.BookQuantity;


                order.Items.Add(
                                 new Item
                                 {
                                     BookId = item.BookId,
                                     Order = order,
                                     BookQuantity = item.BookQuantity

                                 });


            }




            _context.Update(order);

            await _context.SaveChangesAsync();


            return true;


        }


        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

            var items = _context.Items.Where(o => o.OrderId == id).ToList()
                        .Select(g => new
                        {
                            BookId = g.BookId,
                            BookQuantity = g.BookQuantity
                        });



            var book = new Book();
            foreach (var item in items)
            {
                book = await _context.Books.SingleOrDefaultAsync(b => b.Id == item.BookId);
                book.AvailableQuantity += item.BookQuantity;
            }

            _context.Remove(order);
            _context.SaveChanges();
            return true;

        }



    }
    }
