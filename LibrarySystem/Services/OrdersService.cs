using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class OrdersService : IOrdersService
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        public OrdersService(ApplicationDbContext context, IUnitOfWork unitofwork)
        {
            _context = context;
            _unitofwork = unitofwork;
        }
        public async Task<IEnumerable<DisplayOutput>> GetAllOrders()
        {

            var orders = await _unitofwork.Orders.GetAllAsync(o => new DisplayOutput
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
            });




            return orders;


        }


        public async Task<DisplayOutput> GetOrdersByOrderId(int Orderid)
        {

            var orders = await _unitofwork.Orders.GetByIdAsync(o=>o.Id==Orderid,o => new DisplayOutput
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
            });




            return orders;

        }

        public async Task<IEnumerable<DisplayOutput>> GetOrderslate()
        {
            var orders = await _unitofwork.Orders.GetListAsync(
                o => (DateTime.Compare(o.RestorationDate, DateTime.Now) < 0 && o.Restoration.RestorationDate == null),
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
            });




            return orders;

    


        }


        public async Task<IEnumerable<DisplayOutput>> GetOrdersbyOrderDateFilter(DateTime date1, DateTime date2)
        {
            var orders = await _unitofwork.Orders.GetListAsync(
                o => (DateTime.Compare(date1, o.OrderDate) <= 0 && DateTime.Compare(date2, o.OrderDate) >= 0),
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
                });




            return orders;



        }

        public async Task<IEnumerable<DisplayOutput>> GetOrdersbyRestorationDateFilter(DateTime date1, DateTime date2)
        {
            var orders = await _unitofwork.Orders.GetListAsync(
                o => (DateTime.Compare(date1, o.RestorationDate) <= 0 && DateTime.Compare(date2, o.RestorationDate) >= 0),
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
                });




            return orders;


            
        }

        public async Task<IEnumerable<DisplayOutput>> GetOrdersByMemberId(int MemberId)
        {
            var orders = await _unitofwork.Orders.GetListAsync(
                o => o.MemberId == MemberId,
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
                });


            return orders;




        }

        public async Task<IEnumerable<DisplayOutput>> GetOrdersByBookId(int BookId)
        {

            var orders = await _context.Items
                       .Where(o => o.BookId == BookId)
                       .Select(o=> new DisplayOutput
                       {
                           Id=o.Order.Id,
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

                       }
                       )
                       .ToListAsync();

            return orders;


        }

        public async Task<string> AddOrder(OrderDto dto, List<ItemsDto> dto2)
        {
            try
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

                    var book = await _unitofwork.Books.GetByIdAsync(item.BookId);


                    if (book == null)
                    {
                        throw new Exception("wrong Id ");
                        

                    }


                    if (item.BookQuantity > book.AvailableQuantity)
                    {
                        throw new Exception("The quantity is not exist ");

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

                var Order = _unitofwork.Orders.AddAsync(order);
                _unitofwork.Complete();

               // return true;
            }

            catch (Exception e){
                return e.Message ;
            }

            return new string("adedd succefully");




        }


        public async Task<bool> IsOrderRestored(int id)
        {
            var order = await _unitofwork.Orders.GetByIdAsync(id);


            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

            return true;

        }
        
        public async Task<bool> UpdateOrder(int id, EditOrderDto dto,  List<ItemsDto> dto2)
        {
            
            var order = await _unitofwork.Orders.FindByIdAsync(o=>o.Id==id, new[] { "Items" });

            
            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

            if (dto.MemberId == null)
                return false; 

            order.OrderDate = dto.OrderDate;
            order.RestorationDate = dto.RestorationDate;

            order.MemberId = dto.MemberId;


            order.Items = new List<Item>();

            var items = await _unitofwork.Items.GetListAsync(o => o.OrderId == id,
               g => new Item
               {
                   BookId = g.BookId,
                   BookQuantity = g.BookQuantity,
                   
               });




            var book = new Book();
            foreach (var item in items)
            {
                book = await _unitofwork.Books.GetByIdAsync(item.BookId);
                book.AvailableQuantity += item.BookQuantity;
            }



           // _unitofwork.Items.DeleteRange(items);





            foreach (var item in dto2)
            {
                book = await _unitofwork.Books.GetByIdAsync(item.BookId);

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




            _unitofwork.Orders.Update(order);

             _unitofwork.Complete();


            return true;


        }


        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _unitofwork.Orders.GetByIdAsync(id);

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
                book = await _unitofwork.Books.GetByIdAsync(item.BookId);
                book.AvailableQuantity += item.BookQuantity;
            }

            _unitofwork.Orders.Delete(order);
            _unitofwork.Complete();
            return true;

        }



    }
    }
