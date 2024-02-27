using LibrarySystem.Models;
using LibrarySystem.Commands.OrderCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.OrderCommands
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, string>
    {
        private readonly IUnitOfWork _unitofwork;

        public AddOrderHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<string> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var Member = await _unitofwork.Members.GetByIdAsync(request.MemberId);
                if (Member == null)
                    throw new Exception("wrong Id ");

                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    RestorationDate = DateTime.Now.AddDays(7),
                    MemberId = request.MemberId,
                };

                order.Items = new List<Item>();

                //var book = new Book();
                foreach (var item in request.Items)
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

            catch (Exception e)
            {
                return e.Message;
            }

            return new string("adedd succefully");
        }
    }
}
