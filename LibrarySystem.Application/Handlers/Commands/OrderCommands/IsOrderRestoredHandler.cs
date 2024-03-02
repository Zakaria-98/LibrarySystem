using LibrarySystem.Models;
using LibrarySystem.Commands.OrderCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.OrderCommands
{
    public class IsOrderRestoredHandler : IRequestHandler<IsOrderRestoredCommands, bool>
    {
        private readonly IUnitOfWork _unitofwork;

        public IsOrderRestoredHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<bool> Handle(IsOrderRestoredCommands request, CancellationToken cancellationToken)
        {
            var order = await _unitofwork.Orders.GetByIdAsync(request.Id);


            if (order == null)
                return false;
            if (order.RestorationId != null)
                return false;

            return true;
        }
    }
}
