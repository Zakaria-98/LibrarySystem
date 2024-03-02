using LibrarySystem.Models;
using LibrarySystem.Commands.OrderCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.OrderCommands
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IUnitOfWork _unitofwork;

        public DeleteOrderHandler(IUnitOfWork unitofwork, ApplicationDbContext context)
        {
            _unitofwork = unitofwork;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitofwork.Orders.GetByIdAsync(request.Id);

            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

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

            _unitofwork.Orders.Delete(order);
            _unitofwork.Complete();
            return true;
        }
    }
}
