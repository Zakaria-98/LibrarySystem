using LibrarySystem.Models;
using LibrarySystem.Commands.RestorationCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.RestorationCommands
{
    public class AddRestorationHandler : IRequestHandler<AddRestorationCommand, bool>
    {
        private readonly IUnitOfWork _unitofwork;

        public AddRestorationHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<bool> Handle(AddRestorationCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitofwork.Orders.GetByIdAsync(request.Id);

            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

            var restoration = new Restoration
            {
                RestorationDate = DateTime.Now
            };
            restoration.Order = new Order();
            order = await _unitofwork.Orders.GetByIdAsync(request.Id);
            restoration.Order = order;

            var items = await _unitofwork.Items.GetListAsync(o => o.OrderId == request.Id,
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
    }
}
