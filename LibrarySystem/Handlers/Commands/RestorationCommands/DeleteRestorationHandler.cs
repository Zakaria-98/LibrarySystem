using LibrarySystem.Models;
using LibrarySystem.Commands.RestorationCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.RestorationCommands
{
    public class DeleteRestorationHandler : IRequestHandler<DeleteRestorationCommand, bool>
    {
        private readonly IUnitOfWork _unitofwork;

        public DeleteRestorationHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<bool> Handle(DeleteRestorationCommand request, CancellationToken cancellationToken)
        {
            var restoration = await _unitofwork.Restorations.FindByIdAsync(o => o.Id == request.Id, new[] { "Order" });

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
