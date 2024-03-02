using LibrarySystem.Models;
using LibrarySystem.Commands.OrderCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.OrderCommands
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IUnitOfWork _unitofwork;

        public UpdateOrderHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            var order = await _unitofwork.Orders.FindByIdAsync(o => o.Id == request.Id, new[] { "Items" });


            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

            if (request.EditOrderDto.MemberId == null)
                return false;

            order.OrderDate = request.EditOrderDto.OrderDate;
            order.RestorationDate = request.EditOrderDto.RestorationDate;

            order.MemberId = request.EditOrderDto.MemberId;


            order.Items = new List<Item>();

            var items = await _unitofwork.Items.GetListAsync(o => o.OrderId == request.Id,
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





            foreach (var item in request.Items)
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
    }
}
